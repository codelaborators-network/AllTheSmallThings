import React, { Component } from 'react';
import { db } from '../../App';
import XpAggregator from '../helpers/XpAggregator';

class HomepageContent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      totalXP: 0,
      profile: {
        Name: '',
        Image: '',
      }
    };
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.email) {
      this.dbRef = db.ref().child('users').child(nextProps.email.replace('.', ','));
      this.dbRef.on('value', snap => {
        const user = snap.val();
        console.log(user);
        const firstProfileChildKey = Object.keys(user.Profile)[0];

        const totalXP = user.XPEvents ? XpAggregator.calculateTotal(user.XPEvents.values()) : 0;

        const data = {
          profile: user.Profile[firstProfileChildKey],
          totalXP: totalXP,
        };

        this.setState(data);
        console.log(this.state);
      });
    }
  }

  render() {
    return (
      <div className="team-clean">
        <div className="container">
          <div className="row people">
            <div className="col-md-4 col-sm-12 item">
              <img src={`${process.env.PUBLIC_URL}/images/${this.state.profile.Image.replace(',', '.')}`} className="img-circle" alt="user" />
              <h3 className="name">{this.state.profile.Name}</h3>
            </div>
            <div className="col-md-8 col-sm-12">
              <h3>Something about you</h3>
              <p>Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, et interdum justo suscipit id. Etiam dictum feugiat tellus, a semper massa. </p>
              <dl>
                <dt>XP:</dt>
                <dd>{this.state.totalXP}</dd>
                <dt>Level:</dt>
                <dd>5</dd>
                <dt>Health:</dt>
                <dd>100</dd>
                <dt>Gear:</dt>
                <dd>Sword, Dagger, Cross Bow</dd>
              </dl>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default HomepageContent;