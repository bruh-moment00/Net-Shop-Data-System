import React from "react";
import { Nav, PageItem, Pagination } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { getProducts, ProductData } from "../../Data/ProductsData";
import { Page } from "../../LayoutComponents/Page";
import { ProductList } from "../../Objects/ProductsList";

export const ProductsListPage = () => {
  const [products, setProducts] = React.useState<ProductData[] | undefined>([]);
  const [productsLoading, setProductsLoading] = React.useState(true);

  React.useEffect(() => {
    let cancelled = false;
    const doGetProducts = async () => {
      const productsList = await getProducts();
      if (!cancelled) {
        setProducts(productsList);
        setProductsLoading(false);
      }
    };
    doGetProducts();
    return () => {
      cancelled = true;
    };
  }, []);

  const navigate = useNavigate();

  return (
    <Page>
      {productsLoading ? (
        <div>Loading...</div>
      ) : (
        <ProductList data={products || []} />
      )}
      <Nav>
        <Pagination>
          <PageItem></PageItem>
        </Pagination>
      </Nav>
    </Page>
  );
};
