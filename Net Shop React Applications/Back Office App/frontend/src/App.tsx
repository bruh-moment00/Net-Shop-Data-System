import React from "react";
import "./App.css";
import "./CustomStyle.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Routes, Route } from "react-router-dom";

import { Header } from "./LayoutComponents/Header";
import { Page } from "./LayoutComponents/Page";
import { Footer } from "./LayoutComponents/Footer";
import { MainPage } from "./Pages/MainPage";

function App() {
  return (
    <BrowserRouter>
      <div className="page-container">
        <div className="content-wrap">
          <Header />
          <Routes>
            <Route path="" element={<MainPage />} />
          </Routes>
        </div>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;
