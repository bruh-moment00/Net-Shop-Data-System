import React from "react";
import { Link } from "react-router-dom";

import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";
import { getCurrentUser } from "../Services/AuthService";

export const Header = () => {
  const [userName, setUserName] = React.useState<string | undefined>(undefined);

  React.useEffect(() => {
    if (localStorage.getItem("token")) {
      const doGetUserName = async () => {
        const user = await getCurrentUser();
        if (user)
          setUserName(user?.lastName + user?.firstName + user?.secondName);
      };
      doGetUserName();
    }
  });

  return (
    <header>
      <Navbar expand="sm" bg="white" className="border-bottom box-shadow">
        <Container>
          <Navbar.Brand>
            <Link to="/">Name</Link>
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse>
            <Nav className="me-auto">
              <Nav.Link>
                <Link to="/">На главную</Link>
              </Nav.Link>
              <NavDropdown title="Работа с базой">
                <NavDropdown.Item>
                  <Link to="/Products">Товары</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/">Склад</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/">Заказы</Link>
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
            <Nav className="d-flex">
              <NavDropdown title={userName} className="justify-content-end">
                <NavDropdown.Item>
                  <Link to="/Profile">Профиль</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/SignOut">Выход</Link>
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
