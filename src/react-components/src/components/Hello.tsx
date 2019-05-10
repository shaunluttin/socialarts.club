import * as React from "react";
import * as ReactDOM from "react-dom";

interface HelloProps { name: string; }

const Hello = (props: HelloProps) => <h1>Hello from {props.name}.</h1>;

document
    .querySelectorAll('.react-example')
    .forEach((domContainer: any) => {
        const name = domContainer.dataset.name;
        const element = React.createElement(Hello, { name: name });
        ReactDOM.render(element, domContainer);
    })