const path = require('path');

module.exports = {
    entry: './wwwroot/index.js',
    output: {
        path: path.resolve(__dirname, './wwwroot'),
        filename: 'bundle.js'
    }
}