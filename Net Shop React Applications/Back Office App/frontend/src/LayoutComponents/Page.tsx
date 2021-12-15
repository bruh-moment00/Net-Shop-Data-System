import React from "react";
import Container from "react-bootstrap/Container";
import { Title } from "./Title";

interface Props {
  title?: string;
  children: React.ReactNode;
}

export const Page = ({ title, children }: Props) => (
  <Container className="mt-2">
    {title && <Title>{title}</Title>}
    {children}
  </Container>
);
