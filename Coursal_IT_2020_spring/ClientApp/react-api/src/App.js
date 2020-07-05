import React, { Component } from 'react';
import { Layout } from './components/Layout';
import { MainPage } from './components/MainPage';
import { BrowserRouter, Switch, Route, withRouter } from 'react-router-dom';
import { CreateAccount } from './components/CreateAccount';
import { Login } from './components/Login';
import { AddPost } from './components/AddPost';
import axios from "C:/Users/hrani/node_modules/axios";
import ls from 'local-storage';
import { DeleteAccount } from './components/DeleteAccount';
import { DeletePost } from './components/DeletePost';

export default class App extends Component {
    static displayName = App.name;
    constructor() {
        super();
        this.state = {
            loggedInStatus: "NOT_LOGGED_IN",
            user: {},

        }
        this.handleLogin = this.handleLogin.bind(this);
        this.handleLogout= this.handleLogout.bind(this);
    }

    handleLogin(data) {
            this.setState(
                {
                    loggedInStatus: "LOGGED_IN",
                    user: data
                });
    }
    handleLogout(data) {
        this.setState(
            {
                loggedInStatus: "NOT_LOGGED_IN"
            });
    }
    render() {
        return (
            <Layout>
                <BrowserRouter>
                    <Switch>
                        <Route
                            exact
                            path='/'
                            render={props => (
                                <MainPage {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user}/>

                            )}
                        />
                            <Route
                                exact
                                path='/Register'
                            render={props => (
                                <CreateAccount {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user} handleLogin={this.handleLogin}/>

                                )}
                        />
                        <Route
                            exact
                            path='/Login'
                            render={props => (
                                <Login {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user} handleLogin={this.handleLogin}/>

                            )}
                        />
                        <Route
                            exact
                            path='/AddPost'
                            render={props => (
                                <AddPost {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user} handleLogin={this.handleLogin} />

                            )}
                        />
                        <Route
                            exact
                            path='/DeletePost'
                            render={props => (
                                <DeletePost {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user} handleLogin={this.handleLogin} />
                            )}
                        />
                        <Route
                            exact
                            path='/DeleteAccount'
                            render={props => (
                                <DeleteAccount {...props} loggedInStatus={this.state.loggedInStatus} user={this.state.user} handleLogout={this.handleLogout} />
                            )}
                        />   
                    </Switch>
                </BrowserRouter>
            </Layout>
        );
    }
}