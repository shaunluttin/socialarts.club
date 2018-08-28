import * as React from 'react';

// tslint:disable-next-line:interface-name
interface Tool {
    id: string;
    name: string;
    json: string;
    path: string;
}

// tslint:disable-next-line:interface-name
interface Props {
    Tools: Tool[];
}

const renderTool = (tool: Tool) => {
    return (
        <li key={tool.id}>
            <a href={tool.path}>{tool.name}</a>
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