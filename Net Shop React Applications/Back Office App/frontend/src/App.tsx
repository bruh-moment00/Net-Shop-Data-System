import React from "react";
import "./css/App.css";
import "./css/CustomStyle.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { BrowserRouter, Routes, Route } from "react-router-dom";

import { Header } from "./LayoutComponents/Header";
import { Footer } from "./LayoutComponents/Footer";
import { MainPage } from "./Pages/MainPage";
import { ProductPage } from "./Pages/Products/ProductPage";
import { ProductsListPage } from "./Pages/Products/ProductsListPage";
import { AddProductPage } from "./Pages/Products/AddProduct";
import { LoginPage } from "./Pages/LoginPage";
import { ProfilePage } from "./Pages/ProfilePage";
import { SignOutPage } from "./Pages/SignOutPage";
import { AuthRequiredElement } from "./Components/AuthRequired";

function App() {
  return (
    <BrowserRouter>
      <div className="page-container">
        <div className="content-wrap">
          <AuthRequiredElement>
            <Header />
          </AuthRequiredElement>
          <Routes>
            <Route path="" element={<MainPage />} />
            <Route path="Products" element={<ProductsListPage />} />
            <Route path="Products/:productId" element={<ProductPage />} />
            <Route path="Products/Create" element={<AddProductPage />} />
            <Route path="Login" element={<LoginPage />} />
            <Route path="Profile" element={<ProfilePage />} />
            <Route path="SignOut" element={<SignOutPage />} />
          </Routes>
        </div>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;
