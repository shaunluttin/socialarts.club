const path = require('path');
const paths = require('./paths');

// TODO: Replace the es2015 and es2016 presets with babel-preset-env. See babeljs.io/env to update!
const babelOptions = {
    "presets": [
        "react",
        [
            "es2015",
            {
                "modules": false
            }
        ],
        "es2016"
    ]
};

module.exports = {
    entry: {
        early: path.join(paths.entries, 'early.js'),
        late: path.join(paths.entries, 'late.js'),
        react: path.join(paths.entries, 'react.js'),
    },
    output: {
        // See https://webpack.js.org/guides/code-splitting/ for details on code-splitting.
        path: path.join(paths.publicPath, 'dist'),
        publicPath: paths.publicPath,
        // the `name` comes from the `entry` values e.g. early/late
        filename: '[name].bundle.js',
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js', '.json']
    },
    plugins: [
        // this is necessary for ASP.NET Core Hot Module Replacement
    ],
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: babelOptions,
                    },
                    {
                        loader: require.resolve('ts-loader'),
                        options: {
                            // disable type checker - we will use it in fork plugin
                            transpileOnly: true,
                        },
                    },
                ],
            },
            {
                test: /\.(css|scss)$/,
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