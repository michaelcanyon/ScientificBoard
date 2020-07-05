import React from 'react'

const Posts = ({ posts }) => {
    return (
        <div>
            <center><h1>post List</h1></center>
            {posts.map((post) => (
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">{post.Title}</h5>
                    </div>
                </div>
            ))}
        </div>
    )
};

export default Posts