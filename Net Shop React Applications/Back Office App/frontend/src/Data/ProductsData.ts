import { http } from "../http";
import { BrandData } from "./BrandsData";
import { CategoryData } from "./CategoriesData";

export interface ProductDataFull {
  Id: number;
  Category: CategoryData;
  Brand: BrandData;
  Name: string;
  Price: number;
  Description: string;
  Specs: string;
  Image: string;
}

export interface ProductDataFullFromServer {
  id: number;
  category: {
    id: number;
    name: string;
    products: [];
  };
  brand: {
    id: number;
    brand1: string;
    products: [];
  };
  name: string;
  price: number;
  description: string;
  specs: string;
  image: string;
}

export const mapProductFullFromServer = (
  product: ProductDataFullFromServer
): ProductDataFull => ({
  Id: product.id,
  Category: {
    Id: product.category.id,
    Name: product.category.name,
  },
  Brand: {
    Id: product.brand.id,
    Name: product.brand.brand1,
  },
  Name: product.name,
  Price: product.price,
  Description: product.description,
  Specs: product.specs,
  Image: product.image,
});

export interface ProductDataFromServer {
  Id: number;
  CategoryName: string;
  BrandName: string;
  Name: string;
  Price: number;
  Description: string;
  Specs: string;
  ImagePath: string;
}
/*
export const mapProductFromServer = (
  product: ProductDataFromServer
): ProductData => ({
  ...product,
});
*/
export const getProductFull = async (
  productId: number
): Promise<ProductDataFull | null> => {
  const result = await http<ProductDataFullFromServer>({
    path: `/Products/${productId}`,
  });
  if (result.ok && result.body) {
    return mapProductFullFromServer(result.body);
  } else {
    return null;
  }
};
