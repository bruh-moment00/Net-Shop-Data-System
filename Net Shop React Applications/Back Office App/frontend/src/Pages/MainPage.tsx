import React from "react";
import { Link } from "react-router-dom";
import { AuthorizedPage } from "../Components/AuthRequired";
import { Page } from "../LayoutComponents/Page";

export const MainPage = () => {
  return (
    <AuthorizedPage>
      <Page>
        <div className="row">
          <div className="col-xs-12 col-sm-12 col-md-4">
            <Link to="/Products">
              <div className="floating-block transition">
                <h4>Список товаров</h4>
                <p>Добавление, редактирование и удаление товаров</p>
              </div>
            </Link>
          </div>
          <div className="col-xs-12 col-sm-12 col-md-4">
            <Link to="/">
              <div className="floating-block transition">
                <h4>Склад</h4>
                <p>Просмотр и добавление списка товаров на складе</p>
              </div>
            </Link>
          </div>
          <div className="col-xs-12 col-sm-12 col-md-4">
            <Link to="/">
              <div className="floating-block transition">
                <h4>Обработка заказов</h4>
                <p>Работа с заказами, ожидающих обработки</p>
              </div>
            </Link>
          </div>
          <div className="col-xs-12 col-sm-12 col-md-4">
            <Link to="/">
              <div className="floating-block transition">
                <h4>Список сотрудников</h4>
                <p>
                  Просмотр списка сотрудников, регистрация или удаление профилей
                </p>
              </div>
            </Link>
          </div>
          <div className="col-xs-12 col-sm-12 col-md-4">
            <Link to="/Profile">
              <div className="floating-block transition">
                <h4>Профиль</h4>
                <p>Просмотр информации об аккаунте и редактирование</p>
              </div>
            </Link>
          </div>
        </div>
      </Page>
    </AuthorizedPage>
  );
};
