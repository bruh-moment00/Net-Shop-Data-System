import React from "react";

import { Nav, Button } from "react-bootstrap";

import { Link, useSearchParams } from "react-router-dom";

import { getProducts, ProductDataWithPaging } from "../../Data/ProductsData";
import { Page } from "../../LayoutComponents/Page";
import { ProductList } from "../../Components/ProductsList";
import { Paging } from "../../Components/Paging";

export const ProductsListPage = () => {
  const [products, setProducts] = React.useState<
    ProductDataWithPaging | undefined
  >();
  const [productsLoading, setProductsLoading] = React.useState(true);
  const [searchParams] = useSearchParams();

  React.useEffect(() => {
    let cancelled = false;
    const doGetProducts = async (params: URLSearchParams) => {
      const productsList = await getProducts(params);
      if (!cancelled) {
        setProducts(productsList);
        setProductsLoading(false);
      }
    };
    doGetProducts(searchParams);
    return () => {
      cancelled = true;
    };
  }, [searchParams]);

  return (
    <Page title="Товары">
      <Link to="./Create">
        <Button variant="outline-primary">Добавить</Button>
      </Link>
      <hr />
      {productsLoading ? (
        <div>Загрузка...</div>
      ) : (
        <ProductList data={products?.items} />
      )}
      {products !== undefined && (
        <Nav>
          <Paging
            pageNumber={products.currentPage}
            totalPages={products.totalPages}
            hasPrevious={products.hasPrevious}
            hasNext={products.hasNext}
            pageSize={products.pageSize}
          />
        </Nav>
      )}
    </Page>
  );
};
