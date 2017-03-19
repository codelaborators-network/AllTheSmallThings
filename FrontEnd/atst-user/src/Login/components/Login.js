import React, { Component } from 'react';
import { auth } from '../../App';
import { Redirect } from 'react-router-dom';
import '../styles/Login.css';

class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      email: '',
      password: '',
      redirectToReferrer: false
    };
  }

  handleSubmit = (evt) => {
    evt.preventDefault();
    auth.signInWithEmailAndPassword(this.state.email, this.state.password).then(() => {
      this.setState({redirectToReferrer: true});
    });
  };

  render() {
    const {from} = this.props.location.state || '/';
    const {redirectToReferrer} = this.state;

    return (
      <section>
        {redirectToReferrer && (
          <Redirect to={from || '/'}/>
        )}
        <div className="login-clean">
          <form onSubmit={this.handleSubmit}>
            <h2 className="sr-only">Login Form</h2>
            <div className="illustration">
              <i className="icon ion-ios-navigate" />
            </div>
            <div className="form-group">
              <input
                className="form-control"
                type="email"
                name="email"
                placeholder="Email"
                value={this.state.email}
                onChange={e => this.setState({email: e.target.value})}
              />
            </div>
            <div className="form-group">
              <input
                className="form-control"
                type="password"
                name="password"
                placeholder="Password"
                value={this.state.password}
                onChange={e => this.setState({password: e.target.value})}
              />
            </div>
            <div className="form-group">
              <button className="btn btn-primary btn-block" type="submit">Log In</button>
            </div><a href="#" className="forgot">Forgot your email or password?</a></form>
        </div>
      </section>
    );
  }
}

export default Login;