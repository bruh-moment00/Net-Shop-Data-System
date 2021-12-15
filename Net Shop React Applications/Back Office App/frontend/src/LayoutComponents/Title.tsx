import React from "react";

interface Props {
  children: React.ReactNode;
}

export const Title = ({ children }: Props) => <h2>{children}</h2>;
