import React, { Component } from 'react';
import UidProvider from '../../UidProvider';
import HomepageHeader from '../../HomepageHeader/components/HomepageHeader';
import HomepageContent from '../../HomepageContent/components/HomepageContent';

class Homepage extends Component {


  render() {
    return (
      <UidProvider>
        {(email) => (
          <div>
            <HomepageHeader />
            <HomepageContent />
          </div>
        )}
      </UidProvider>
    );
  }
}

export default Homepage;