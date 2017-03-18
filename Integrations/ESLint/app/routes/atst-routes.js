const doLint = require('../BL/doLint');

module.exports = function(app) {
    app.post('/lint', (req, res) => {
        doLint(req.body);

        res.sendStatus(200);
    });
};