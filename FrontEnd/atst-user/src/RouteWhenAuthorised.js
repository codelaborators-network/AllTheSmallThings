import React from 'react';
import { isAuthenticated } from './App';
import { Redirect, Route } from 'react-router-dom';

const RouteWhenAuthorized = ({component: Component, ...rest}) => (
  <Route {...rest} render={renderProps => (
    isAuthenticated() ? (
        <Component {...renderProps} />
      ) : (
        <Redirect to={ {
          pathname: '/login',
          state: {from: renderProps.location}
        } } />
      )
  )}/>
);

export default RouteWhenAuthorized;