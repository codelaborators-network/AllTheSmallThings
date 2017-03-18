const express = require('express');
const bodyParser = require('body-parser');

const app = express();

const port = process.env.PORT || 8000;

app.use(bodyParser.json());

require('./app/routes')(app);

app.listen(port, () => {
  console.log(`Go go gadget port number: ${port}!`);
});
