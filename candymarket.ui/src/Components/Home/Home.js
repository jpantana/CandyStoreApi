import React from 'react';
import firebase from 'firebase/app';
import 'firebase/auth';
import CandyList from '../CandyList/CandyList';
import UserList from '../UserList/UserList.js';


class Home extends React.Component {
    logoutEvent = (e) => {
        e.preventDefault();
        firebase.auth().signOut();
    };

    render() {
        return (
            <div>
                <button className="btn btn-danger" onClick={this.logoutEvent}>Logout</button>
                <div className="row">
                    <UserList />
                    <CandyList />
                </div>
            </div>
        )
    }
}

export default Home;
