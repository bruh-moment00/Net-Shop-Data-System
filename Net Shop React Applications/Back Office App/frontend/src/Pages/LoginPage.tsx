import React from "react";
import { LoginForm } from "../Components/LoginForm";
import { Page } from "../LayoutComponents/Page";
import { useNavigate } from "react-router-dom";
import { isTokenValid } from "../Services/AuthService";

export const LoginPage = () => {
  const navigate = useNavigate();

  const [loadThisPage, setLoadThisPage] = React.useState(false);

  React.useEffect(() => {
    if (localStorage.getItem("token")) {
      let cancelled = false;
      const doGetTokenStatus = async () => {
        const tokenValid = await isTokenValid();
        if (!cancelled) {
          if (tokenValid) navigate("/Profile");
          else setLoadThisPage(true);
        }
      };
      doGetTokenStatus();
      return () => {
        cancelled = true;
      };
    } else setLoadThisPage(true);
  });

  return (
    <Page title="Вход в систему">{loadThisPage ? <LoginForm /> : <></>}</Page>
  );
};
