const request = require('request');

module.exports = function(app) {
    app.post('/lint', (req, res) => {
        console.log(`Alright bro, I'm just gonna go get ${req.body} real quick`);
        request.get(req.body, (error, response,body) => {
            if (!error && response.statusCode === 200) {
                console.log(body);
            }
        });
        res.send('Yo dawg!!!');
    });
};