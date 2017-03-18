const request = require('request');
const linter = require('eslint').linter;

module.exports = (fileUrl) => {
  console.log(`Alright bro, I'm just gonna go get ${fileUrl} real quick`);
  request.get(fileUrl, (error, response, body) => {
    if (error || response.statusCode !== 200) {
      throw new Error(`Oh crap son! We got an error on our hands man!\r\n${error}`);
    }

    console.log(`Sweet as a nut, I got ${fileUrl}`);
    console.log(`Let's see what ESLint thinks of this bad boy`);

    const fileNameParts = fileUrl.split('/');
    const fileName = fileNameParts[fileNameParts.length - 1];

    const messages = linter.verify(body, {
      rules: {
        semi: 2,
      }
    }, { filename: fileName});

    console.log(messages);
  });
};

