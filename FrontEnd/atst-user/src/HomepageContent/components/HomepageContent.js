import React, { Component } from 'react';

class HomepageContent extends Component {
  render() {
    return (
      <div className="team-clean">
        <div className="container">
          <div className="row people">
            <div className="col-md-4 col-sm-12 item">
              <img src="assets/img/zac.jpg" className="img-circle" alt="user" />
              <h3 className="name">Zac Braddy</h3>
            </div>
            <div className="col-md-8 col-sm-12">
              <h3>Something about you</h3>
              <p>Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, et interdum justo suscipit id. Etiam dictum feugiat tellus, a semper massa. </p>
              <dl>
                <dt>XP:</dt>
                <dd>50</dd>
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