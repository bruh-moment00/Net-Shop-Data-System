import React from "react";
import "./css/App.css";
import "./css/CustomStyle.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Routes, Route } from "react-router-dom";

import { Header } from "./LayoutComponents/Header";
import { Footer } from "./LayoutComponents/Footer";
import { MainPage } from "./Pages/MainPage";
import { ProductPage } from "./Pages/ProductPage";

function App() {
  return (
    <BrowserRouter>
      <div className="page-container">
        <div className="content-wrap">
          <Header />
          <Routes>
            <Route path="" element={<MainPage />} />
            <Route path="Products/:productId" element={<ProductPage />} />
          </Routes>
        </div>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;
