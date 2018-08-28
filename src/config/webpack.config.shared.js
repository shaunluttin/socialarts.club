const path = require('path');

module.exports = {
    entry: {
        early: './wwwroot-src/webpack/early.js',
        late: './wwwroot-src/webpack/late.js',
        react: './react-components-ts/src/index.tsx',
    },
    output: {
        // See https://webpack.js.org/guides/code-splitting/ for details on code-splitting.
        path: path.join(__dirname, 'wwwroot', 'dist'),
        publicPath: '/wwwroot/',
        // the `name` comes from the `entry` values e.g. early/late
        filename: '[name].bundle.js',
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js', '.json']
    },
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                use: [
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