import React, { Component } from 'react';
import axios from "C:/Users/hrani/node_modules/axios";
import { withRouter } from 'react-router-dom';
import ls from 'local-storage';
import './AuthorisingStyles.css'


export class DeleteAccount extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            nickname: "",
            password: "",
            passwordConfirmation: ""
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
        axios.post("http://localhost:5000/api/User/accountDel", {
            nickname: this.state.nickname,
            password: this.state.password,
            passwordConfirmation: this.state.passwordConfirmation
        }, { withCredentials: false }
        ).then(response => {
            if (response.statusText === "OK") {
                console.log(response);
                this.props.handleLogout(response.data);
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
                            <input class="inputreg" type="password" name="password" placeholder="Password" value={this.state.password} onChange={this.handleChange} required />
                            <input class="inputreg" type="passwordConfirmation" name="passwordConfirmation" placeholder="PasswordConfirmation" value={this.state.passwordConfirmation} onChange={this.handleChange} required />
                            <button type="submit">Delete</button>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}
