import * as React from 'react';
import { cleanup, render } from 'react-testing-library';
import ToolsList, { Tool } from './ToolsList';

afterEach(cleanup);

test('ToolsList.render should output header and item list', async () => {
    // arrange 
    const tools: Tool[] = [
        {
            Id: 'tool-id-01',
            Name: 'tool-name-01',
            Path: '/tool-path-01'
        },
        {
            Id: 'tool-id-02',
            Name: 'tool-name-02',
            Path: '/tool-path-02'
        },
    ];

    // act
    const toolsList = render(<ToolsList Tools={tools} />);

    // assert
    const header = toolsList.getByText('Tools');
    const listItems = toolsList.getAllByText(/^tool-name/g)

    expect(header.nodeName).toBe('H2');
    expect(listItems).toHaveLength(2);
    expect(toolsList).toMatchSnapshot();
});