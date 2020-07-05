import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { CreateAccount } from '../CreateAccount';
import { Login } from '../Login';
import ls from 'local-storage';
import './AccountStatus.css';
export default class AccountStatus extends Component {
    constructor(props) {
        super(props);
        this.handleLogoutClick = this.handleLogoutClick.bind(this);
    }


    handleLogoutClick() {
        this.setState(state => ({
            loggedInStatus: "NOT_LOGGED_IN",
            user : ""
        }));
        window.location.reload();
    }
    render() {
        if (this.props.loggedInStatus === "NOT_LOGGED_IN") {
            return (
                <div>
                    <div>
                        <h2>Status:{this.props.loggedInStatus}</h2>
                        <ul className="page_headline-list page_headline-perks login_button abcd">
                        <li><Link to="/Login">
                            <Button>
                                <p>Sign In</p>
                            </Button>
                        </Link></li>
                            <li><Link to="/Register">
                            <Button>
                                <p>Sign Up</p>
                                </Button>
                            </Link></li>
                        </ul>
                    </div>
                </div>
            );
        }
        else {
            return (
                <div>
                    <div>
                        <h2>Status:{this.props.loggedInStatus}</h2>
                        <h2>Nickname: {this.props.user.nickname}</h2>
                        <h2>Email: {this.props.user.email}</h2>
                        <h2>Blog title: {this.props.user.blogTitle}</h2>
                        <Link>
                            <Button onClick={this.handleLogoutClick}>
                                <p>Log out</p>
                            </Button>
                        </Link>
                        <Link to="/AddPost">
                            <Button>
                                <p>Add post</p>
                            </Button>
                        </Link>
                        <Link to="/DeletePost">
                            <Button>
                                <p>Delete post</p>
                            </Button>
                        </Link>
                        <Link to="/DeleteAccount">
                            <Button>
                                <p>Delete Account</p>
                            </Button>
                        </Link>
                    </div>
                </div>
            );
        }
    }
}