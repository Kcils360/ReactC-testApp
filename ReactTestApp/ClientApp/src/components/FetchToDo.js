import React, { Component } from 'react';

export class FetchToDo extends Component {
    static displayname = FetchToDo.name;

    constructor(props) {
        super(props);
        this.state = { todos: [], loading: true };

        fetch('api/ToDoes/GetToDos')
            .then(response => response.json())
            .then(data => {
                this.setState({ todos: data, loading: false });
            });
    }

    static renderToDosTable(todos) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Task Name</th>
                        <th>Description</th>
                        <th>Done</th>
                    </tr>
                </thead>
                <tbody>
                    {todos.map(todo =>
                        <tr key={todo.taskName}>
                            <td>{todo.taskName}</td>
                            <td>{todo.taskDescription}</td>
                            <td><input type="checkbox" /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchToDo.renderToDosTable(this.state.todos);

        return (
            <div>
                <h1>Some Tasks To Do</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}

