import React from 'react';

class Candy extends React.Component {

    render() {
        return (
            <div id={this.props.candy.id}>{ this.props.candy.name }</div>
        )
    }
}

export default Candy;
