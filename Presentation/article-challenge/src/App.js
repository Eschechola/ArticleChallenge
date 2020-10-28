import React from 'react';

import Header from './components/header/index.js';
import Footer from './components/footer/index.js';
import Routes from './routes';

import './styles.css';

const App = () =>(
  <div className="App">
      <Routes/>
      <Footer/>
    </div>
);


export default App;
