import React, { Component } from 'react';
import { Redirect, Link } from 'react-router-dom';
import logo from '../../images/login-image.svg'
import axios from 'axios';

import './styles.css';

class Main extends Component
{
    constructor(props) {
        super();

        this.state = {
            email: "",
            password: "",

            inputError: false,
            inputMessage: ""
        }

        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
    }

    handleEmailChange(e){
        this.setState({email: e.target.value});
    }

    handlePasswordChange(e){
        this.setState({password: e.target.value});
    }

    handleLogin = async () => {
        await axios.post(
            'https://localhost:44392/api/v1/user/authenticate',
            this.state
        )
        .then(res => {
            localStorage.clear();
            localStorage.setItem('user', JSON.stringify(res.data));

            this.props.history.push('/artigos');
        })
        .catch(err => {
            this.setState({inputError: true});
            this.setState({inputMessage: "Usuário e/ou senha estão inválido(s)."});
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
                <div class="login-content">
                    <img class="logo" src={logo} alt="Logo" />

                    <form>
                        <input type="text" class="login-input" placeholder="Digite seu email" required value={this.state.email} onChange={this.handleEmailChange} />

                        <br/>

                        <input type="password" class="login-input" placeholder="Digite sua senha" required value={this.state.password} onChange={this.handlePasswordChange} />

                        <h5>Ainda não tem acesso? <Link to={`/cadastro/`} class="register-url">Cadastre-se</Link></h5>

                        <span class="error" style={this.state.inputError ? displayBlock : displayNone}>
                            {this.state.inputMessage}
                        </span>

                        <button type="button" class="btn-send" onClick={this.handleLogin}>Login</button>
                    </form>
                </div>
            </section>
        )
    }
}

export default Main;