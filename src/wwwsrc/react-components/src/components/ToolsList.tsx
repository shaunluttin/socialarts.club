import * as React from 'react';

// tslint:disable-next-line:interface-name
interface Tool {
    Id: string;
    Name: string;
    Path: string;
}

// tslint:disable-next-line:interface-name
interface Props {
    Tools: Tool[];
}

const renderTool = (tool: Tool) => {
    return (
        <li key={tool.Id}>
            <a href={tool.Path}>{tool.Name}</a>
        </li>
    );
};

function ToolsList({ Tools }: Props) {
    return (
        <div className='ToolsList'>
            <h2>Tools</h2>
            {Tools.map(renderTool)}
        </div>
    );
}

export default ToolsList;

export {
    Tool,
    Props,
}