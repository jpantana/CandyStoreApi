import React from 'react';
import firebase from 'firebase/app';
import 'firebase/auth';

class Auth extends React.Component {
  state = {
    signUpClicked: '',
    signupEmail: '',
    signupPassword: '',
    loginEmail: '',
    loginPassword: '',
    isOpen: false,
  }

  loginClickEvent = (e) => {
    e.preventDefault();
    const provider = new firebase.auth.GoogleAuthProvider();
    firebase.auth().signInWithPopup(provider);
  };

  render() {
    return (
      <div className="Auth">

        <button className="btn googleBtn" onClick={this.loginClickEvent}>
          <img className="googleIcon" src="https://image.flaticon.com/teams/slug/google.jpg" alt="google icon" />
          Continue With Google
        </button>
      </div>
    );
  }
}

export default Auth;
