import React from 'react';
import {
  Route,
  Redirect,
  BrowserRouter,
  Switch,
} from 'react-router-dom';
import firebase from 'firebase/app';
import fbConnection from './Requests/Data/connection.js';
import Auth from './Auth.js';

import Home from './Components/Home/Home.js';

import './Styles/App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

fbConnection();

const PublicRoute = ({
  component: Component,
  authed,
  ...rest
}) => {
  const routeChecker = props => (authed === false
    ? (<Component {...props} />)
    : (<Redirect to={{ pathname: '/home', state: { from: props.location } }} />)
  );
  return <Route {...rest} render={props => routeChecker(props)} />;
};

const PrivateRoute = ({
  component: Component,
  authed,
  ...rest
}) => {
  const routeChecker = props => (authed === true
    ? (<Component {...props} />)
    : (<Redirect to={{ pathname: '/auth', state: { from: props.location } }} />)
  );
  return <Route {...rest} render={props => routeChecker(props)} />;
};

class App extends React.Component {

  state = {
    authed: false,
    useruid: '',
  }

  componentDidMount() {
    this.removeListener = firebase.auth().onAuthStateChanged((user) => {
      if (user) {
        this.setState({ authed: true, useruid: user.uid });
      } else {
        this.setState({ authed: false });
      }
    });
  }

  componentWillUnmount() {
    this.removeListener();
  }
 render() {
  const {
    authed,
  } = this.state;
  return (
      <div className="App">
        <BrowserRouter>
          <React.Fragment>
            <div className="wrapper d-flex">
              <div className="col justify-center">
                <Switch>
                  <PublicRoute path="/auth" component={Auth} authed={authed} />
                  <PrivateRoute path="/home" component={Home} authed={authed} />
                  <Redirect from="*" to="/auth" />
                </Switch>
              </div>
            </div>
          </React.Fragment>
        </BrowserRouter>
      </div>
    )
  }
}

export default App;
