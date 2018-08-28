import * as React from 'react';
import { cleanup, render } from 'react-testing-library';
import ToolsList, { Tool } from './ToolsList';

afterEach(cleanup);

const getData = (length: number) => Array.from(Array(length).keys()).map(i => {
    return {
        id: `id-${i}`,
        json: `json-${i}`,
        name: `name-${i}`,
        path: `path-${i}`,
        templateUrlPath: `templateUrlPath-${i}`,
    } as Tool;
});

test('ToolsList.render should output header', async () => {
    // arrange 
    const expectedLength = 3;
    const tools = getData(expectedLength);

    // act
    const toolsList = render(<ToolsList Tools={tools} />);

    // assert
    const header = toolsList.getByText('Tools');
    expect(header.nodeName).toBe('H2');
    expect(toolsList).toMatchSnapshot();
});

test('ToolsList.render should output correct number of list items', async () => {
    // arrange 
    const count = 3;
    const tools = getData(count);

    // act
    const toolsList = render(<ToolsList Tools={tools} />);

    // assert
    const listItems = toolsList.getAllByText(/^name-/g)
    expect(listItems).toHaveLength(count);
    expect(toolsList).toMatchSnapshot();
});

test('ToolsList.render should use correct href for each named item', async () => {
    // arrange 
    const count = 2;
    const tools = getData(count);

    // act
    const toolsList = render(<ToolsList Tools={tools} />);

    // assert
    for(const tool of tools) {
        const path = `${tool.templateUrlPath}/${tool.id}`;
        const item = toolsList.getByText(tool.name);
        expect(item.nodeName).toBe('A');
        expect(item.getAttribute('href')).toBe(path);
    }
});