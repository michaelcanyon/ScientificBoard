import React, { Component } from 'react';
import axios from "C:/Users/hrani/node_modules/axios";
import { withRouter } from 'react-router-dom';
import ls from 'local-storage';
import './AuthorisingStyles.css'

export class AddPost extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.TextChange = this.TextChange.bind(this);
        this.state = {
            tag: "",
            title: "",
            tags: [],
            text: "",
        }
    }
    handleChange(event) {
        this.setState(
            {
                [event.target.name]: event.target.value
            }
        );
    }
    TextChange(event) {
       var buffString = event.target.value.replace(/\n/g, '');
        this.setState(
            {
                [event.target.name]: buffString
            }
        );
    }
    handleSubmit(event) {
        axios.put("https://localhost:5001/api/Post/post", {
            nickname: this.props.user.nickname,
            password: this.props.user.password,
            title: this.state.title,
            tags: this.state.tags,
            text: this.state.text
        }, { withCredentials: false }
        ).then(response => {
            if (response.status === 200) {
                console.log(response);
                this.props.history.push('/');
            }
        }).catch(error => {
            console.log("Registration error", error);
        });
        event.preventDefault();
    }
    addtag() {
        var newArray = this.state.tags;
        newArray.push(this.state.tag);
        this.setState({ tags: newArray })
    }
    render() {
        return (
            <div>
                <div classNameName="auth_header_size">
                    <h2 classNameNameName="auth_header">Enter post data:</h2>
                </div>
                <div classNameName="auth_forms_size">
                    <div classNameName="auth_forms">
                        <form onSubmit={this.handleSubmit}>
                            <input className="inputreg" type="title" name="title" placeholder="Title" value={this.state.title} onChange={this.handleChange} required />
                            <textarea type="text" value={this.state.text} placeholder="Text" name="text" onChange={this.TextChange} required />
                            <button type="submit">Post</button>
                        </form>
                        <input className="inputreg" type="tag" name="tag" placeholder="Tag" value={this.state.tag} onChange={this.handleChange} required />
                        <button type="submit" onClick={this.addtag.bind(this)} >Add tag</button>
                    </div>
                </div>
            </div>
        );
    }
}
