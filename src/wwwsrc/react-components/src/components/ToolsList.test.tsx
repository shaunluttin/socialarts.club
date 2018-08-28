import * as React from 'react';
import { cleanup, render } from 'react-testing-library';
import ToolsList, { Tool } from './ToolsList';

afterEach(cleanup);

test('ToolsList.render should output header and item list', async () => {
    // arrange 
    const tools: Tool[] = [
        {
            id: 'tool-id-01',
            json: '',
            name: 'tool-name-01',
            path: '/tool-path-01'
        },
        {
            id: 'tool-id-02',
            json: '',
            name: 'tool-name-02',
            path: '/tool-path-02'
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