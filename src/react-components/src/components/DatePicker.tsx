import * as React from "react";
import * as ReactDOM from "react-dom";
import DatePicker from "react-datepicker";

import "react-datepicker/dist/react-datepicker.css";

// TODO Use a function not a class.
class MyDatePicker extends React.Component {
    constructor(props: any) {
        super(props);
        this.state = {
            startDate: new Date()
        };
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(date: any) {
        this.setState({
            startDate: date
        });
    }

    render() {
        return (
            <DatePicker
                // TODO Add types for state.
                // @ts-ignore
                selected={this.state.startDate}
                onChange={this.handleChange}
            />
        );
    }
}

document
    .querySelectorAll('.date-picker')
    .forEach((domContainer: any) => {
        const element = React.createElement(MyDatePicker);
        ReactDOM.render(element, domContainer);
    })