import React from 'react';
import PropTypes from 'prop-types';
import userCandyRequest from '../../Requests/userCandyRequest.js';
import UserCandy from '../UserCandy.js';

class UserCandyList extends React.Component {
    static propTypes = {
        callbackHomeForTrade: PropTypes.func.isRequired,
    }

    state = {
        allUserCandy: [],
    }

    componentDidMount() {
        this.getMyUserCandy();
    }

    getMyUserCandy = () => {
        userCandyRequest.getAllUserCandy().then((data) => {
            this.setState({ allUserCandy: data });
        }).catch(err => console.log(err));
    };

    showSingleUserCandy = () => {
        const allUserCandy = [...this.state.allUserCandy];
        return allUserCandy.map(userCandy => (
            <UserCandy
                key={userCandy.id}
                userCandy={userCandy}
                callbackHomeForTrade={this.props.callbackHomeForTrade}
            />

        ));
    };


    render() {
        return (
            <div>
                <h1>User Candy List:</h1>
                { this.showSingleUserCandy() }
            </div>
        )
    }
}

export default UserCandyList;
