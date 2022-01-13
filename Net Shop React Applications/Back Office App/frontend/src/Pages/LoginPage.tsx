import React from "react";
import { LoginForm } from "../Components/LoginForm";
import { Page } from "../LayoutComponents/Page";
import { useNavigate } from "react-router-dom";

export const LoginPage = () => {
  const navigate = useNavigate();
  React.useEffect(() => {
    if (localStorage.getItem("token")) {
      navigate("/Profile");
    }
  });

  return (
    <Page title="Вход в систему">
      <LoginForm />
    </Page>
  );
};
