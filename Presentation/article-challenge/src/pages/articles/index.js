import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import Header from '../../components/header'

import './styles.css';

class Articles extends Component
{
    constructor(props){
        super();
        
        if(localStorage.getItem("user") == null){
            props.history.push('/');
        }
    }

    state = {
        user: JSON.parse(localStorage.getItem('user')),
        articles: []
    }

    componentDidMount(){
        this.getArticles();
    }

    getArticles = async () => {
        await axios.get(
            'https://localhost:44392/api/v1/articles/get-all',
        )
        .then(res => {
            this.setState({articles: res.data.data});
        })
        .catch(err => {
            alert(err);
        });
    }

    render(){
        const usernameMessage = 'Olá, ' + this.state.user.data.name; 
        
        var articles = this.state.articles;

        return(
            <section class="articles">
                <Header username={usernameMessage}/>

                <h4>Todos os artigos</h4>

                <div class="articles-content">
                    {
                        articles.map(
                            article => (
                                <article key = {article.id}>
                                    <h5><strong>{article.title.toUpperCase()}</strong></h5>
                                    
                                    <br/>
                                    
                                    <Link to={`/artigo/${article.id}`}>Acessar</Link>
                                </article>
                            )
                        )
                    }
                </div>
            </section>
        )
    }
}

export default Articles;