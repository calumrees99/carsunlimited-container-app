import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { QueryClient, QueryClientProvider } from 'react-query'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import 'reflect-metadata';

//pages
import { Cart, HomePage, Inventory, Product } from './pages';

const queryClient = new QueryClient()

ReactDOM.render(
  <React.StrictMode>   
    <QueryClientProvider client={queryClient}>
      <Router>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/Cars" element={<Inventory category="Car" displayName="Cars" />} />
          <Route path="/Accessories" element={<Inventory category="Accessory" displayName="Accessories" />} />
          <Route path="/Parts" element={<Inventory category="Part" displayName="Parts" />} />
          <Route path="/Product/:manufacturer/:model" element={<Product />} />
          <Route path="/Cart" element={<Cart />} />
        </Routes>
      </Router>
    </QueryClientProvider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
