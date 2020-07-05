import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import Posts from './Components/Posts';

class App extends Component {
    state = {
        posts: []
    }
    componentDidMount() {
        fetch('http://localhost:5000/api/Post/posts')
            .then(res => res.json())
            .then((data) => {
                this.setState({ posts: data })
            })
            .catch(console.log)
    }
render() {
    return (<Posts posts={this.state.posts} />)
}
}
export default App;
