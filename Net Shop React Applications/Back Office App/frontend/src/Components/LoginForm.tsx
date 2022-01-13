import React from "react";
import { Button, Col, Form } from "react-bootstrap";

import { useForm } from "react-hook-form";

import { login } from "../Services/AuthService";
import { useNavigate } from "react-router-dom";

type FormData = {
  email: string;
  password: string;
};

export const LoginForm = () => {
  const [loading, setLoading] = React.useState(false);

  const navigate = useNavigate();
  const {
    register,
    formState: { errors, isSubmitting },
    handleSubmit,
  } = useForm<FormData>({
    mode: "onBlur",
  });

  const submitForm = (data: FormData) => {
    setLoading(true);
    login(data.email, data.password).then(() => {
      navigate("/Profile");
      setLoading(false);
      window.location.reload();
    });
  };

  return (
    <Form onSubmit={handleSubmit(submitForm)}>
      <Form.Group className="row mt-3">
        <Col xl={3} xs={12}>
          <Form.Label>Электронная почта</Form.Label>
        </Col>
        <Col xl={9} xs={12}>
          <Form.Control
            id="email"
            type="email"
            placeholder="Электронная почта"
            {...register("email", {
              required: true,
            })}
          />
        </Col>
      </Form.Group>
      <Form.Group className="row mt-3">
        <Col xl={3} xs={12}>
          <Form.Label>Пароль</Form.Label>
        </Col>
        <Col xl={9} xs={12}>
          <Form.Control
            id="password"
            type="password"
            placeholder="Пароль"
            {...register("password", {
              required: true,
            })}
          />
        </Col>
      </Form.Group>
      {loading ? (
        <Button variant="primary" type="button" disabled className="mt-3">
          Войти
        </Button>
      ) : (
        <Button variant="primary" type="submit" className="mt-3">
          Войти
        </Button>
      )}
    </Form>
  );
};
