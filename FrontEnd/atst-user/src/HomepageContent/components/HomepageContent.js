import React, { Component } from 'react';
import { db } from '../../App';
import XpAggregator from '../helpers/XpAggregator';
import LevelAggregator from '../helpers/LevelAggregator';
import GearAggregator from '../helpers/GearAggregator';

class HomepageContent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      totalXP: 0,
      profile: {
        Name: '',
        Image: '',
      },
      level: 0,
      gear: [],
      profilePic: `${process.env.PUBLIC_URL}/images/default.png`,
    };
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.email) {
      this.dbRef = db.ref().child('users').child(nextProps.email.replace('.', ','));
      this.dbRef.on('value', snap => {
        const user = snap.val();
        console.log(user);
        const firstProfileChildKey = Object.keys(user.Profile)[0];
        const profile = user.Profile[firstProfileChildKey];

        const totalXP = user.XPEvents ? XpAggregator.calculateTotal(Object.values(user.XPEvents)) : 0;
        const level = user.Levels ? LevelAggregator.calculateTotal(Object.values(user.Levels)) : 0;
        const gear = user.Gear ? GearAggregator.calculateTotal(Object.values(user.Gear)) : [];

        const data = {
          profile: profile,
          totalXP: totalXP,
          level: level,
          gear: gear,
          profilePic: `${process.env.PUBLIC_URL}/images/${profile.Image.replace(',', '.').length > 0 ? profile.Image.replace(',', '.') : 'default.png'}`,
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
              <img src={`${this.state.profilePic}`} className="img-circle" alt="user" />
              <h3 className="name">{this.state.profile.Name}</h3>
            </div>
            <div className="col-md-8 col-sm-12">
              <h3>Something about you</h3>
              <p>Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, et interdum justo suscipit id. Etiam dictum feugiat tellus, a semper massa. </p>
              <dl>
                <dt>XP:</dt>
                <dd>{this.state.totalXP}</dd>
                <dt>Level:</dt>
                <dd>
                  {this.state.level}
                </dd>
                <dt>Health:</dt>
                <dd>100</dd>
                <dt>Gear:</dt>
                <dd>
                  <div className="row gear-row">
                    {this.state.gear.map((item, i) => <div key={i} className="col-md-3">{item}</div>)}
                  </div>
                </dd>
              </dl>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default HomepageContent;