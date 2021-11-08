import React from "react";
import { Link, useNavigate } from "react-router-dom";

import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";

export const Header = () => {
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
                  <Link to="/">Товары</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/">Склад</Link>
                </NavDropdown.Item>
                <NavDropdown.Item>
                  <Link to="/">Заказы</Link>
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
