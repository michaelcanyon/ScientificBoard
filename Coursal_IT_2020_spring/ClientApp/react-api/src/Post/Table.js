import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
class Table extends Component {
    constructor(props) {
        super(props);
    }
    DeletePost = () => {
        axios.delete('http://localhost:5000/api/Post/post' + this.props.obj.Id)
            .then(json => {
                if (json.data.Status === 'Delete') {
                    alert('Record deleted successfully!!');
                }
            })
    }
    render() {
        return (
            <tr>
                <td>
                    {this.props.obj.title}
                </td>
                <td>
                    {this.props.obj.text}
                </td>
                <td>
                    {this.props.obj.author.nickname}
                </td>
                <td>
                    {this.props.obj.author.email}
                </td>
                <td>
                    <Link to={"/edit/" + this.props.obj.Id} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button type="button" onClick={this.DeletePost} className="btn btn-danger">Delete</button>s
                </td>
            </tr>
        );
    }
}
export default Table;