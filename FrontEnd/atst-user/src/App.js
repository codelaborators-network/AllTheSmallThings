import React, { Component } from 'react';
import RouteWhenAuthorized from './RouteWhenAuthorised';
import Homepage from './HomePage';
import Login from './Login';
import { createBrowserHistory } from 'history';
import { BrowserRouter, Route } from 'react-router-dom';

import firebase from 'firebase';

let config = {
  apiKey: "AIzaSyAT_tC7ukLEAW5Y9tzssc_WNGRPJgrl_sc",
  authDomain: "all-the-small-things-7b52b.firebaseapp.com",
  databaseURL: "https://all-the-small-things-7b52b.firebaseio.com",
  storageBucket: "all-the-small-things-7b52b.appspot.com",
  messagingSenderId: "386456203688"
};

export const firebaseApp = firebase.initializeApp(config);

export const db = firebaseApp.database();
export const auth = firebaseApp.auth();

export const storageKey = 'ALL_THE_SMALL_THINGS_STORAGE';
export const history = createBrowserHistory();

export const isAuthenticated = () => {
  return !!auth.currentUser || !! localStorage.getItem(storageKey);
};

import './App.css';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      email: null,
    }
  }

  static childContextTypes = {
    email: React.PropTypes.string
  }

  getChildContext() {
    return {email: this.state.email};
  }

  componentDidMount() {
    auth.onAuthStateChanged((user) => {
      if (user) {
        window.localStorage.setItem(storageKey, user.email);
        this.setState({email: user.email});
      } else {
        window.localStorage.removeItem(storageKey);
        this.setState({email: null});
      }
    });
  }

  render() {
    return (
      <BrowserRouter>
        <div>
          <Route path="/login" component={Login} />
          <RouteWhenAuthorized exact path="/" component={Homepage} />
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
