const path = require('path');

module.exports = {
    entry: {
        early: './wwwroot/early.js',
        late: './wwwroot/late.js',
    },
    output: {
        // See https://webpack.js.org/guides/code-splitting/ for details on code-splitting.
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, './wwwroot'),
    },
    module: {
        rules: [
            {
                test: /\.(scss)$/,
                use: [{
                    loader: 'style-loader', // inject CSS to page
                }, {
                    loader: 'css-loader', // translates CSS into CommonJS modules
                }, {
                    loader: 'postcss-loader', // Run post css actions
                    options: {
                        plugins: function () { // post css plugins, can be exported to postcss.config.js
                            return [
                                require('precss'),
                                require('autoprefixer')
                            ];
                        }
                    }
                }, {
                    loader: 'sass-loader' // compiles Sass to CSS
                }]
            }
        ]
    }
}