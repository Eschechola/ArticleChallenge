import React, {Component} from 'react';
import logo from '../../images/login-image.svg';

import './styles.css'

class Header extends Component {
    render(){
        return  <header>
                    <div class="container-1">
                        <img class="logo" src={logo} alt="Logo" />
                    </div>

                    <div class="container-3">
                        <h3>{this.props.username}</h3>
                    </div>

                    <div class="container-15"></div>

                    <div class="container-1">
                        <a href="/artigos">Artigos</a>
                    </div>

                    <div class="container-1">
                        <a href="/sair">Sair</a>
                    </div>
                </header>
    }
}

export default Header;