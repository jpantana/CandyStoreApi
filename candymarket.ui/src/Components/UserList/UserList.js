import React from 'react';
import userRequest from '../../Requests/userRequest.js';
import User from '../User.js';

class UserList extends React.Component {
    state = {
        allUsers: [],
    }

    componentDidMount() {
        this.getMyUser();
    }

    getMyUser = () => {
        userRequest.getAllUsers().then((data) => {
            this.setState({ allUsers: data });
        }).catch(err => console.log(err));
    };

    showSingleUser = () => {
        const allUsers = [...this.state.allUsers];

        return allUsers.map(user => (
            <User
                key={user.id}
                user={user}
            />

        ));
    };


    render() {
        return (
            <div>
                <h1>User List:</h1>
                { this.showSingleUser() }
            </div>
        )
    }
}

export default UserList;
