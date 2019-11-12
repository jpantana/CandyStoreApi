import React from 'react';
import candyRequest from '../../Requests/candyRequest.js';
import Candy from '../Candy.js';

class CandyList extends React.Component {
    state = {
        me: true,
        allCandy: [],
    }

    componentDidMount() {
        this.getMyCandy();
    }

    getMyCandy = () => {
        candyRequest.getAllCandy().then((data) => {
            this.setState({ allCandy: data });
        }).catch(err => console.log(err));
    };

    showSingleCandy = () => {
        const allCandy = [...this.state.allCandy];

        return allCandy.map(candy => (
            <Candy
                key={candy.id}
                candy={candy}
            />

        ));
    };


    render() {
        return (
            <div>
                <h1>Candy List:</h1>
                { this.showSingleCandy() }
            </div>
        )
    }
}

export default CandyList;
