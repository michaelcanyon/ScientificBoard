import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { NavLink } from 'reactstrap';

export class Posts extends Component {
    static displayName = Posts.name;

    constructor(props) {
        super(props);

        this.state = {
            post: {},
            IsLoaded: false,
        };
    }



    async componentDidMount() {
        let url = `http://localhost:5000/api/Post/posts`
        await axios.get(url)
            .then(res => res.data)
            .then((data) => {
                this.setState({ IsLoaded: true, product: data })
            })
            .catch(console.log);
    }

    render() {
        var { IsLoaded, post } = this.state;
        if (!IsLoaded) {
            return (
                <p>
                    Loading.
                </p>
            );
        }
        else {
            return (
                <div>
                    <h1>{post.title}</h1>
                    <div><strong>TEXT:</strong>:{post.text}</div>
                    <NavLink tag={Link} to={`/deleted${post.id}`}>Delete</NavLink><p>|</p><NavLink tag={Link} to={`/update_product${post.id}`}>Change</NavLink>
                </div>
            );
        }
    }
}