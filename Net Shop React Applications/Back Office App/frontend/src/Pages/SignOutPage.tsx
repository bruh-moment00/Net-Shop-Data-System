import React from "react";
import { useNavigate } from "react-router-dom";
import { Page } from "../LayoutComponents/Page";
import { logout } from "../Services/AuthService";

export const SignOutPage = () => {
  const navigate = useNavigate();
  React.useEffect(() => {
    logout();
    navigate("/Login");
  });

  return (
    <Page title="Выход...">
      <div></div>
    </Page>
  );
};
