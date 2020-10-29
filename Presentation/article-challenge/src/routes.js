import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Main from './pages/main';
import Articles from './pages/articles'
import Article from './pages/article'
import Logout from './pages/logout';
import Register from './pages/register';

const Routes = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/" component={Main}/>
                <Route exact path="/cadastro" component={Register}/>
                <Route exact path="/artigos" component={Articles}/>
                <Route path="/artigo/:ID" component={Article}/>
                <Route exact path="/sair" component={Logout}/>
            </Switch>
        </BrowserRouter>
    );
}
export default Routes;