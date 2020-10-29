import React, {Component} from 'react';
import axios from 'axios';
import './styles.css'
import Header from '../../components/header'

import like from '../../images/like.svg';

class Article extends Component
{
    constructor(props){
        super();
        
        if(localStorage.getItem("user") == null){
            props.history.push('/');
        }
    }

    state ={
        user: JSON.parse(localStorage.getItem('user')),
        article: {}
    }


    async componentDidMount(){
        const { ID } = this.props.match.params;
        await this.getArticle(ID);
    }

    getArticle = async (articleID) => {
        await axios.get(
            'https://localhost:44392/api/v1/articles/get/' + articleID,
        )
        .then(res => {
            this.setState({article: res.data.data});
        })
        .catch(err => {
            alert(err);
        });
    }


    render(){
        const usernameMessage = 'Olá, ' + this.state.user.data.name; 
        const title = this.state.article.title;
        const text = this.state.article.text;
        const likes = this.state.article.mountLikes;

        return <section>
                    <Header username={usernameMessage}/>

                    <div class="modal-like">
                        <p class="mount-likes">{ likes }</p>
                        <img class="logo" src={like} alt="Logo" />
                    </div>

                    <article class="article-content">
                        <h2 class="title">
                            { title }
                        </h2>
                        
                        <br/>

                        <p class="text">
                            { text }
                        </p>
                    </article>
               </section> 
    }
}

export default Article;