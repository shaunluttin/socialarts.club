import * as React from 'react';
import ToolsList, { Tool } from "./components/ToolsList";

class App extends React.Component {

  public render() {
    return (
      <div className="App">
        <ToolsList Tools={this.getTools()} />
      </div>
    );
  }

  private getTools(): Tool[] {
    return [
      {
        Id: '01',
        Name: '01',
        Path: '/01',
      },
      {
        Id: '02',
        Name: '02',
        Path: '/02',
      },
    ];
  }
}

export default App;
