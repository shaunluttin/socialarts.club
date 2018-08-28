import * as React from 'react';
import ToolsList, { Tool } from "./components/ToolsList";

class App extends React.Component {

  public state = {
    tools: [] as Tool[]
  }

  public render() {
    return (
      <div className="App">
        <ToolsList Tools={this.state.tools} />
      </div>
    );
  }

  public async componentDidMount() {
    const tools = await this.getTools();
    this.setState({ tools });
  }

  private async getTools(): Promise<Tool[]> {
    // TODO: inject this URL via props.
    // TODO: inject an IO service via props.
    return fetch('https://localhost:5001/api/tools')
      .then((response) => response.json());
  }
}

export default App;
