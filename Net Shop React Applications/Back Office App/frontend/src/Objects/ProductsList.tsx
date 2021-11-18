import React from "react";

import { Page } from "../LayoutComponents/Page";
import { ProductData } from "../Data/ProductsData";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";

interface Props {
  data: ProductData[];
}

export const ProductList = ({ data }: Props) => (
  <Table>
    <thead>
      <tr>
        <th>Наименование</th>
        <th>Цена</th>
        <th>Производитель</th>
        <th>Категория</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      {data.map((product) => (
        <tr key={product.id}>
          <td>
            <Link to={`/Products/${product.id}`}>
              {product.name}
              <br />
              {product.image ? <img src={product.image} height="150" /> : ""}
            </Link>
          </td>
          <td>{product.price}</td>
          <td>{product.brand}</td>
          <td>{product.category}</td>
          <td>
            Изменить | <Link to={`/Products/${product.id}`}>Подробно</Link> |
            Удалить
          </td>
        </tr>
      ))}
    </tbody>
  </Table>
);
