import React, {Component} from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import './styles.css'
import Header from '../../components/header'

import like from '../../images/like.svg';

class Article extends Component
{
    state ={
        user: JSON.parse(localStorage.getItem('user')),
        article: {},
        like: null
    }


    async componentDidMount(props){
        if (localStorage.getItem('user') != null) {
            const { ID } = this.props.match.params;
            const userId = JSON.parse(localStorage.getItem('user')).data.id;

            await this.getArticle(ID);
            await this.getLike(ID, userId);
        }
    }

    getLike = async (articleId, userId) =>{
        await axios.get(
            `https://localhost:44392/api/v1/articles/get-like/${userId}/${articleId}`
        )
        .then(res =>{
            this.setState({like: res.data.data})
        })
        .catch(err=>{
            alert(err);
        })
    }

    getArticle = async (articleID) => {
        await axios.get(
            `https://localhost:44392/api/v1/articles/get/${articleID}`,
        )
        .then(res => {
            this.setState({article: res.data.data});
        })
        .catch(err => {
            alert(err);
        });
    }

    likeArticle = async (articleId, userId) => {
        await axios.post(
            'https://localhost:44392/api/v1/articles/add-like',
            {
                articleId: articleId,
                userId: userId
            }
        )
        .then(res =>{
            this.setState(prevState =>({
                article: {
                    ...prevState.article,
                    mountLikes: res.data.data
                }
            }));

            this.setState({like: {articleId: articleId, userId: userId}});
        })
        .catch(err=>{
            alert(err);
        });
    }

    unlikeArticle= async (articleId, userId) => {
        await axios.post(
            'https://localhost:44392/api/v1/articles/remove-like',
            {
                articleId: articleId,
                userId: userId
            }
        )
        .then(res =>{
            this.setState(prevState =>({
                article: {
                    ...prevState.article,
                    mountLikes: res.data.data
                }
            }));

            this.setState({like: null});
        })
        .catch(err=>{
            alert(err);
        });
    }

    buttonLiked(){
        return (
            <img title="deslike" class="logo" src={like} alt="Logo" style={{filter: 'grayscale(0%)'}} onClick={() => this.unlikeArticle(this.state.article.id, this.state.user.data.id)}/>
        );
    }

    buttonUnliked(){
        return (
            <img title="like" class="logo" src={like} alt="Logo" onClick={() => this.likeArticle(this.state.article.id, this.state.user.data.id)}/>
        );
    }


    render(){
        if (localStorage.getItem('user') == null) {
            return <Redirect to={{ pathname: '/', state: { from: this.props.location } }} />
        }

        const usernameMessage = 'Olá, ' + this.state.user.data.name; 
        const title = this.state.article.title;
        const text = this.state.article.text;
        const likes = this.state.article.mountLikes;
        
        let button;

        if(this.state.like != null){
            button = this.buttonLiked();
        }
        else{
            button = this.buttonUnliked();
        }


        return <section>
                    <Header username={usernameMessage}/>

                    <div class="modal-like">
                        <p class="mount-likes">{ likes }</p>
                        { button }
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