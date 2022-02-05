import React from "react";
import { Page } from "../LayoutComponents/Page";
import { getCurrentUser, isTokenValid } from "../Services/AuthService";
import { useNavigate } from "react-router-dom";
import { Role } from "../Data/RolesData";

interface Props {
  requiredRole?: Role;
  children?: React.ReactNode;
}

export const AuthRequiredElement: React.FC = ({
  requiredRole,
  children,
}: Props) => {
  const [isAuthorized, setIsAuthorized] = React.useState(false);

  React.useEffect(() => {
    let cancelled = false;
    if (localStorage.getItem("token")) {
      const doGetTokenStatus = async () => {
        if (requiredRole !== undefined) {
          const userInfo = await getCurrentUser();
          if (!cancelled && userInfo && userInfo.role === requiredRole) {
            setIsAuthorized(true);
          }
        } else {
          const tokenValid = await isTokenValid();
          if (!cancelled && tokenValid) setIsAuthorized(true);
        }
      };
      doGetTokenStatus();
      return () => {
        cancelled = true;
      };
    }
  }, []);

  if (isAuthorized) {
    return <>{children}</>;
  } else {
    return null;
  }
};

export const AuthorizedPage = ({ requiredRole, children }: Props) => {
  const navigate = useNavigate();
  const [isAuthorized, setIsAuthorized] = React.useState(false);
  const [message, setMessage] = React.useState("");

  React.useEffect(() => {
    let cancelled = false;

    if (localStorage.getItem("token")) {
      const doGetTokenStatus = async () => {
        if (requiredRole !== undefined) {
          const userInfo = await getCurrentUser();
          if (!cancelled) {
            if (userInfo && userInfo.role === requiredRole) {
              setIsAuthorized(true);
            } else setMessage("Недостаточно прав для просмотра");
          }
        } else {
          const tokenValid = await isTokenValid();
          if (!cancelled) {
            if (tokenValid) setIsAuthorized(true);
            else {
              setMessage(
                "Окончен срок действия токена, необходима повторная авторизация"
              );
              navigate("/Login");
            }
          }
        }
      };
      doGetTokenStatus();
      return () => {
        cancelled = true;
      };
    } else {
      setMessage("Доступ закрыт. Вы не авторизованы.");
      navigate("/Login");
    }
  }, [navigate]);

  if (isAuthorized) {
    return <>{children}</>;
  } else {
    return <Page>{message}</Page>;
  }
};
