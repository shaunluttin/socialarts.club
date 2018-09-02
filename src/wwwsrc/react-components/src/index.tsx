import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import * as repository from './repository';

ReactDOM.render(
  <App getTools={repository.getTools} />,
  document.getElementById('root') as HTMLElement
);

registerServiceWorker();
