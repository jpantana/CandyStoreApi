import React from 'react';

class User extends React.Component {

    render() {
        return (
            <div id={`user${this.props.user.id}`}>{ this.props.user.firstName } {this.props.user.lastName }</div>
        )
    }
}

export default User;
