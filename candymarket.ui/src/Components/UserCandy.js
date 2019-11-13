import React from 'react';
import PropTypes from 'prop-types'
import candyRequest from '../Requests/candyRequest.js';
import userRequest from '../Requests/userRequest.js';

class UserCandy extends React.Component {
    static propTypes = {
        callbackHomeForTrade: PropTypes.func.isRequired,
    }

    state = {
        thisCandy: '',
        candyOwner: '',
        thisCandyId: -1,
        thisOwnerId: -1,
    }

    componentDidMount() {
        this.whichCandy();
        this.whoOwnsIt();
    }

    whichCandy = () => {
        candyRequest.whichCandy(this.props.userCandy.candyId).then((data) => {
            this.setState({ thisCandy: data.name, thisCandyId: data.id });
        }).catch(err => console.error(err));
    };

    whoOwnsIt = () => {
        userRequest.whoOwnsCandy(this.props.userCandy.userId).then((data) => {
            const fullname = (data[0].firstName + ' ' + data[0].lastName);
            this.setState({ candyOwner: fullname, thisOwnerId: data[0].id });
        }).catch(err => console.error(err));
    };

    eventHomeForTrade = (e) => {
        e.preventDefault();
        const { callbackHomeForTrade, userCandy } = this.props;
        const { thisCandyId } = this.state;
        callbackHomeForTrade(userCandy.id, thisCandyId);
        // next function will take oldUserId and candy id, and add to new table to track trade history
    }

    render() {
        return (
            <div id={`usercandy${this.props.userCandy}`}>
                <div>
                    Candy: { this.state.thisCandy }
                </div>

                <div>
                    Owner: { this.state.candyOwner }
                </div>

                <button
                    className="btn btn-primary"
                    onClick={this.eventHomeForTrade}
                >Trade Candy</button>
            </div>
        )
    }
}

export default UserCandy;
