import React from "react";
import { User } from "../Data/UserData";
import { Page } from "../LayoutComponents/Page";
import { getCurrentUser } from "../Services/AuthService";

export const ProfilePage = () => {
  const [currentUser, setCurrentUser] = React.useState<User>();

  React.useEffect(() => {
    let cancelled = false;
    const doGetCurrentUser = async () => {
      const foundUser = await getCurrentUser();
      if (!cancelled) {
        setCurrentUser(foundUser);
      }
    };
    doGetCurrentUser();
    return () => {
      cancelled = true;
    };
  }, []);
  return <Page title="Профиль">{JSON.stringify(currentUser)}</Page>;
};
