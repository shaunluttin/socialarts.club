import * as React from 'react';
import ToolsList, { Tool } from "./components/ToolsList";

// tslint:disable-next-line:interface-name
interface Props {
  getTools: () => Promise<Tool[]>
}

class App extends React.Component<Props> {

  public state = {
    tools: [] as Tool[]
  }

  constructor(props: any) {
    super(props);
  }

  public render() {
    return (
      <div className="App">
        <ToolsList Tools={this.state.tools} />
      </div>
    );
  }

  public async componentDidMount() {
    const tools = await this.props.getTools();
    this.setState({ tools });
  }
}

export default App;
