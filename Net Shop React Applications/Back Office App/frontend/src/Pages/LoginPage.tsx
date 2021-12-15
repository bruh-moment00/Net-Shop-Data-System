import React from "react";
import { Form, Button, Col, Row } from "react-bootstrap";
import { Page } from "../LayoutComponents/Page";

export const LoginPage = () => {
  return (
    <Page title="Вход в систему">
      <Form>
        <Form.Group className="row mt-3">
          <Col xl={3} xs={12}>
            <Form.Label>Электронная почта</Form.Label>
          </Col>
          <Col xl={9} xs={12}>
            <Form.Control type="email" placeholder="Электронная почта" />
          </Col>
        </Form.Group>
        <Form.Group className="row mt-3">
          <Col xl={3} xs={12}>
            <Form.Label>Пароль</Form.Label>
          </Col>
          <Col xl={9} xs={12}>
            <Form.Control type="password" placeholder="Пароль" />
          </Col>
        </Form.Group>
        <Button variant="primary" type="submit" className="mt-3">
          Войти
        </Button>
      </Form>
    </Page>
  );
};
