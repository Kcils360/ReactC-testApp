import React, { Component } from 'react';


export class FetchToDo extends Component {
    static displayname = FetchToDo.name;

    constructor(props) {
        super(props);
        this.setDone = this.setDone.bind(this);
        this.newAlert = this.newAlert.bind(this);
        this.state = { todos: [], loading: true };

        fetch('api/ToDoes/GetToDos')
            .then(response => response.json())
            .then(data => {
                this.setState({ todos: data, loading: false });
            });
    }

    newAlert() {
        console.log("this sucks");
    }

    setDone(id) {
        console.log(id);
        console.log(this.state.todos);
        //this.setState({ this.state.todos  = true })
    }

    renderToDosTable(todos) {
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
                        <tr key={todo.taskName} style={{ textDecoration: todo.isDone ? 'line-through' : 'none', visibility: todo.isDone ? 'hdden' : 'visible' }}  >
                            <td>{todo.taskName}</td>
                            <td>{todo.taskDescription}</td>
                            <td>{todo.isDone.toString()}</td>
                            <td>
                                <button onClick={() => this.setDone(todo.id)} style={{ visibility: todo.isDone ? 'hidden' : 'visible' }} >Done</button>
                            </td>
                        </tr>
            
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderToDosTable(this.state.todos);

        return (
            <div>
                <h1>Some Tasks To Do</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}


