import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Main from './pages/main';
//import Article from './pages/aritcle'

const Routes = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/" component={Main}/>
                
            </Switch>
        </BrowserRouter>
    );
}
//<Route path="/article/:ID" component={Article}/>
export default Routes;