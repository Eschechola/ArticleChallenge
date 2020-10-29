import React, { Component } from 'react';

class Logout extends Component
{
    constructor(props){
        super();

        localStorage.clear();
        props.history.push('/');
    }

    render(){
        return <p></p>
    }
}

export default Logout;