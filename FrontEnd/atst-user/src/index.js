import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
global.jQuery = require('jquery');
require('bootstrap');
import 'bootstrap/dist/css/bootstrap.css';
import './HomepageHeader/styles/HomepageHeader.css';
import './HomepageContent/styles/HomepageContent.css';

import './common/fonts/ionicons.eot';
import './common/fonts/ionicons.min.css';
import './common/fonts/ionicons.svg';
import './common/fonts/ionicons.ttf';
import './common/fonts/ionicons.woff';

ReactDOM.render(
  <App />,
  document.getElementById('root')
);

