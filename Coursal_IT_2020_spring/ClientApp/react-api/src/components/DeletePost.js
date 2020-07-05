import React, { Component } from 'react';
import axios from "C:/Users/hrani/node_modules/axios";
import { withRouter } from 'react-router-dom';
import ls from 'local-storage';
import './AuthorisingStyles.css'


export class DeletePost extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            title: ""
        }
    }
    handleChange(event) {
        this.setState(
            {
                [event.target.name]: event.target.value
            }
        );
    }

    handleSubmit(event) {
        axios.post("https://localhost:5001/api/Post/postDel", {
            nickname: this.props.user.nickname,
            title: this.state.title
        }, { withCredentials: false }
        ).then(response => {
            console.log("DATA:", response);
            console.log("password:", this.props.user.password);
            if (response.status === 200) {
                console.log(response);
                this.props.history.push('/');
            }
        }).catch(error => {
            console.log("Registration error", error);
        });
        event.preventDefault();
    }
    render() {
        return (
            <div>
                <div className="auth_header_size">
                    <h2 classNameName="auth_header">Enter Post Title:</h2>
                </div>
                <div className="auth_forms_size">
                    <div className="auth_forms">
                        <form onSubmit={this.handleSubmit}>
                            <input class="inputreg" type="title" name="title" placeholder="Title" value={this.state.title} onChange={this.handleChange} required />
                            <button type="submit">Delete</button>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}
