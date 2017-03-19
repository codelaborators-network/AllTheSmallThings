import React, { Component } from 'react';
import UidProvider from './UidProvider';
import { auth } from './App';

class Homepage extends Component {
  handleClick = () => {
    auth.signOut();
  };

  render() {
    return (
      <UidProvider>
        {(email) => (
          <div>
            <div>
              Logged in as: {email}
            </div>
            <button onClick={this.handleClick}>
              SignOut
            </button>
          </div>
        )}
      </UidProvider>
    );
  }
}

export default Homepage;