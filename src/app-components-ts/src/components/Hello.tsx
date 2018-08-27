import * as React from 'react';

export interface IProps {
    name: string;
    enthusiasmLevel?: number;
}

function Hello({ name, enthusiasmLevel = 1 }: IProps) {
    return (
        <div>
            Hello {name}
        </div>
    );

}

export default Hello;