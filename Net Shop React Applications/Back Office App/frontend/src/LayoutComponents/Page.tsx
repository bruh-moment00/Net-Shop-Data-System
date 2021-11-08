import React from "react";
import Container from "react-bootstrap/Container";

interface Props {
  title?: string;
  children: React.ReactNode;
}

export const Page = ({ title, children }: Props) => (
  <Container>{children}</Container>
);
