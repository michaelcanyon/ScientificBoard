import React, { Component } from 'react';
import axios from "C:/Users/hrani/node_modules/axios";
import AccountStatus from './auth/AccountStatus';
import './MainPage.css';
import ls from 'local-storage';


export class MainPage extends Component {
    static displayName = MainPage.name;
    constructor(props) {
        super(props);
        this.state = {
            posts: [],
            IsLoaded: false,
            Search: "",
            SearchByNickname: "",
        }
    }
    async componentDidMount() {
        await axios.get('https://localhost:5001/api/Post/posts')
            .then(res => res.data)
            .then((data) => {
                this.setState({ IsLoaded: true, posts: data })
            })
            .catch(console.log);
    }
    updateSearch(event) { this.setState({ Search: event.target.value }); }
    updateSearchByNickname(event) { this.setState({ SearchByNickname: event.target.value }); }
    render() {
        let filteredPosts = this.state.posts.filter(
            (post) => {
                if (this.state.Search === "") {
                    return post;
                }
                return post.tags.indexOf(this.state.Search) !== -1;
            }

        );
        filteredPosts = filteredPosts.filter(
            (post) => {
                if (this.state.SearchByNickname === "") {
                    return post;
                }
                if (post.author.nickname === this.state.SearchByNickname) {
                    return post;
                }
                //return post.author.nickname.indexOf(this.state.SearchByNickname) !== -1;
            }

        );
        return (
            <div className="page">
                <div className="page_headline">
                    <img className="page_headline_logo-image" src="https://pngriver.com/wp-content/uploads/2018/03/Download-Science-PNG-File-For-Designing-Work.png" />
                    <ul className="page_headline-list page_headline-perks login_button abcd">
                        <li><input type="tag" label="Tag" placeholder="Фильтр по тегу" value={this.state.Search} onChange={this.updateSearch.bind(this)} /></li>
                        <li><input type="nickname" label="Nickname" placeholder="Фильтр по автору" value={this.state.SearchByNickname} onChange={this.updateSearchByNickname.bind(this)} /></li>
                    </ul>
                </div>
                {filteredPosts.map((post) => (
                    <div className="page_post">
                        <div className="post_header">
                            <img className="post_author-avatar" src="https://pngimage.net/wp-content/uploads/2018/05/avatar-png-2.png" />
                            <span className="post_header-text">{post.title}</span>
                            <span className="post_date-time">{post.publicationtime}</span>
                            {post.tags.map((tag) => (<span className="post_tags">{tag}</span>))}
                        </div>
                        <img className="post_picture" src="https://sciencejournal.withgoogle.com/static/images/social.png" />
                        <p className="post_preview">{post.text}</p>
                        <p className="post_preview">{post.author.nickname}</p>
                    </div>

                ))}
                <div className="page_recent-posts-block">
                    <div className="short_post">
                        <img className="short-post_author-avatar" src="https://pngimage.net/wp-content/uploads/2018/05/avatar-png-2.png" />
                        <span><AccountStatus {...this.props} loggedInStatus={this.props.loggedInStatus} user={this.props.user} /></span>
                    </div>
                </div>
                <div class="page_footer">
                    <span class="page_footer-copyright">© Powered by Chechuga Michael</span>
                </div>
            </div>
        );
    }
}