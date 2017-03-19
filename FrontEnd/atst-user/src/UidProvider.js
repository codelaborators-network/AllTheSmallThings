import React, { Component } from 'react';

class UidProvider extends Component {
  static contextTypes = {
    email: React.PropTypes.string
  };

  render() {
    return this.props.children(this.context.email);
  }
}

export default UidProvider;