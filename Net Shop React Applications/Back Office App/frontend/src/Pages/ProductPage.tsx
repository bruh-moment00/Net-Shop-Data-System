import React from "react";

import { Page } from "../LayoutComponents/Page";

import { useParams } from "react-router-dom";
import { Button } from "react-bootstrap";

import {
  ProductDataFull,
  getProductFull,
  ProductDataFromServer,
} from "../Data/ProductsData";

export const ProductPage = () => {
  const [product, setProduct] = React.useState<ProductDataFull | null>(null);

  const { productId } = useParams();

  React.useEffect(() => {
    let cancelled = false;
    const doGetProduct = async (productId: number) => {
      const foundProduct = await getProductFull(productId);
      if (!cancelled) {
        setProduct(foundProduct);
      }
    };
    if (productId) {
      doGetProduct(Number(productId));
    }
    return () => {
      cancelled = true;
    };
  }, [productId]);

  return (
    <Page>
      <div>
        <div>
          <h1>Подробно</h1>
        </div>
        <div>
          <dl className="row">
            <dt className="col-sm-2">Наименование</dt>
            <dd className="col-sm-10">{product?.Name}</dd>
            <dt className="col-sm-2">Цена</dt>
            <dd className="col-sm-10">{product?.Price}</dd>
            <dt className="col-sm-2">Описание</dt>
            <dd className="col-sm-10">{product?.Description}</dd>
            <dt className="col-sm-2">Характеристики</dt>
            <dd className="col-sm-10">{product?.Specs}</dd>
            <dt className="col-sm-2">Производитель</dt>
            <dd className="col-sm-10">{product?.Brand.Name}</dd>
            <dt className="col-sm-2">Категория</dt>
            <dd className="col-sm-10">{product?.Category.Name}</dd>
          </dl>
        </div>
        <div>
          <Button variant="link">Назад</Button>
        </div>
      </div>
    </Page>
  );
};
