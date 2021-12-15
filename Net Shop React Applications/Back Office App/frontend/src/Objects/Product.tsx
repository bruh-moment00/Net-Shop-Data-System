import React from "react";

import { ProductDataFull } from "../Data/ProductsData";

import { Link } from "react-router-dom";

interface Props {
  data: ProductDataFull;
  showContent?: boolean;
}

export const Product = ({ data, showContent = true }: Props) => (
  <div>
    <Link to={`/Products/${data.id}`}>{data.name}</Link>
  </div>
);
