import React from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home.js';
import './custom.css'

 const App = () => {    

     return (
             <Route exact path='/' component={Home} />
         );
     
}
export default App;
