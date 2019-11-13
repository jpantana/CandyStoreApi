import React from 'react';
import firebase from 'firebase/app';
import 'firebase/auth';
import CandyList from '../CandyList/CandyList.js';
import UserList from '../UserList/UserList.js';
import UserCandyList from '../UserCandyList/UserCandyList.js';
import userCandyRequest from '../../Requests/userCandyRequest.js';


class Home extends React.Component {
    state = {
        didTrade: false,
    }

    logoutEvent = (e) => {
        e.preventDefault();
        firebase.auth().signOut();
    };

    callbackHomeForTrade = (id, candyId) => {
        const update = {
            "CandyId": candyId,
            "UserId": 6,
            "IsTraded": true,
        }
        userCandyRequest.makeTrade(id, update)
        .then((res) => {
            console.error('inhome', res);
            this.setState({ didTrade: true });
        }).catch(err => console.error(err));
    };


    render() {
        return (
            <div>
                <button className="btn btn-danger" onClick={this.logoutEvent}>Logout</button>
                <div className="row w-100">
                    <UserList />
                    <UserCandyList
                        callbackHomeForTrade={this.callbackHomeForTrade}
                    />
                    <CandyList />
                </div>
            </div>
        )
    }
}

export default Home;
