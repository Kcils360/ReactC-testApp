import React, { Component } from 'react';

export class ToDoApp extends Component {
    static displayName = ToDoApp.name;

    constructor(props) {
        super(props);
        this.state = {
            number: 0
        };
        this.saveToDo = this.saveToDo.bind(this);
    }

    saveToDo() {
        this.setState({
            number: this.state.number + 1
        });
    }

    render() {
        return (
            <div>
                <h1>To Do App</h1>

                <p>Type Here</p>
                <input type="text" />
                <button className="btn btn-primary" onClick={this.saveToDo}>Save</button>

                <p>Number of ToDos: {this.state.number}</p>
            </div>

        );
    }
}