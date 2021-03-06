import React, { Component } from 'react';
import { Link, Redirect } from 'react-router-dom';
import logo from '../../images/login-image.svg'
import axios from 'axios';

import './styles.css';

class Register extends Component
{
    constructor(props) {
        super();

        this.state = {
            name: "",
            email: "",
            password: "",

            inputError: false,
            inputMessage: ""
        }

        if(localStorage.getItem("user") != null){
            props.history.push('/artigos');
        }

        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
    }

    handleNameChange(e){
        this.setState({name: e.target.value});
    }

    handleEmailChange(e){
        this.setState({email: e.target.value});
    }

    handlePasswordChange(e){
        this.setState({password: e.target.value});
    }

    handleLogin = async () => {
        await axios.post(
            'https://localhost:44392/api/v1/user/create',
            this.state
        )
        .then(res => {
            localStorage.clear();
            localStorage.setItem('user', JSON.stringify(res.data));

            this.props.history.push('/artigos');
        })
        .catch(err => {
            this.setState({inputError: true});
            this.setState({inputMessage: "Corrija os campos e tente novamente."});
        });
    }


    render(){

        const displayNone = {
            display: "none"
        }

        const displayBlock = {
            display: "block"
        }

        if (localStorage.getItem('user') != null) {
            return <Redirect to={{ pathname: '/artigos', state: { from: this.props.location } }} />
        }

        return( 
            <section class="login">
                <div class="register-content">
                    <img class="logo" src={logo} alt="Logo" />

                    <form>

                        <input name="name" type="text" class="login-input" placeholder="Digite seu nome" required value={this.state.name} onChange={this.handleNameChange} />

                        <br/>

                        <input name="email" type="text" class="login-input" placeholder="Digite seu email" required value={this.state.email} onChange={this.handleEmailChange} />                        

                        <br />

                        <input name="password" type="password" class="login-input" placeholder="Digite sua senha" required value={this.state.password} onChange={this.handlePasswordChange} />
                        
                        <h5>Ja tem uma conta? <Link to={'/'} class="register-url">Logue</Link></h5>

                        <span class="error" style={this.state.inputError ? displayBlock : displayNone}>
                            {this.state.inputMessage}
                        </span>

                        <button type="button" class="btn-send" onClick={this.handleLogin}>Entrar</button>
                    </form>
                </div>
            </section>
        )
    }
}

export default Register;