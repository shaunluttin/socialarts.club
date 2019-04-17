const path = require('path');
const paths = require('./paths');

module.exports = {
    entry: {
        early: path.join(paths.entries, 'early.js'),
        late: path.join(paths.entries, 'late.js'),
        'react-components': path.join(paths.entries, 'react-components.js'),
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
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            }
        ]
    }
}