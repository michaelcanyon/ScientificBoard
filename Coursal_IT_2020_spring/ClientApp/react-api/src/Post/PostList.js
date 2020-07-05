import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';
export default class Postlist extends Component {
    constructor(props) {
        super(props);
        this.state = { business: [] };
    }
    componentDidMount() {
        debugger;
        axios.get('http://localhost:5000/api/Post/posts')
            .then(response => {
                this.setState({ business: response.data });
                //debugger;
            })
            .catch(function (error) {
                console.log(error);
            })
    }
    tabRow() {
        return this.state.business.map(function (object, i) {
            return <Table obj={object} key={i} />;
        });
    }
    render() {
        return (
            <div>
                <h4 align="center">Post List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>title</th>
                            <th>text</th>
                            <th>author.nickname</th>
                            <th>author.email</th>
                            <th colSpan="4">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.tabRow()}
                    </tbody>
                </table>
            </div>
        );
    }
}