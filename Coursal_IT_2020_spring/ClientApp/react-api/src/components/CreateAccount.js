import React, { Component } from 'react';
import axios from "C:/Users/hrani/node_modules/axios";
import { withRouter } from 'react-router-dom';
import ls from 'local-storage';
import './AuthorisingStyles.css'


export class CreateAccount extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.state = { 
                nickname: "",
                email: "",
                password: "",
                blogTitle: ""
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
        axios.put("http://localhost:5000/api/User/account", {
                nickname: this.state.nickname,
                email: this.state.email,
                password: this.state.password,
                blogTitle: this.state.blogTitle
        }, { withCredentials: false }
        ).then(response => {
            if (response.statusText === "OK") {
                console.log(response);
                this.props.handleLogin(response.data); 
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
                    <h2 classNameName="auth_header">Enter account data:</h2>
                </div>
                <div className="auth_forms_size">
                    <div className="auth_forms">
                <form onSubmit={this.handleSubmit}>
                            <input class="inputreg" type="nickname" name="nickname" placeholder="Nickname" value={this.state.nickname} onChange={this.handleChange} required />
                            <input class="inputreg" type="email" name="email" placeholder="Email" value={this.state.email} onChange={this.handleChange} required />
                            <input class="inputreg" type="blogTitle" name="blogTitle" placeholder="BlogTitle" value={this.state.blogTitle} onChange={this.handleChange} required />
                            <input class="inputreg" type="password" name="password" placeholder="Password" value={this.state.password} onChange={this.handleChange} required />
                            <button type="submit">Sign up</button>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}
