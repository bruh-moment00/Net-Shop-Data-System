import React from "react";
import { Button } from "react-bootstrap";
import { createBrowserHistory } from "history";

export const BackButton = () => {
  let history = createBrowserHistory();
  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    history.back();
  };
  return (
    <Button variant="link" onClick={handleClick}>
      Назад
    </Button>
  );
};
