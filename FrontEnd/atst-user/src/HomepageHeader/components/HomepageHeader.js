import React, { Component } from 'react';
import { auth } from '../../App';

class HomepageHeader extends Component {
  handleClick = () => {
    auth.signOut();
  };

  render() {
    return (
      <nav className="navbar navbar-default navigation-clean">
        <div className="container">
          <div className="navbar-header"><a href="#" className="navbar-brand navbar-link">All the small things</a>
          </div>
          <div id="navcol-1">
            <ul className="nav navbar-nav navbar-right">
              <li role="presentation" className="active" onClick={this.handleClick}>
                <a href="#" className="btn btn-primary btn-block">Logout <i className="glyphicon glyphicon-log-out" /></a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    );
  }
}

export default HomepageHeader;