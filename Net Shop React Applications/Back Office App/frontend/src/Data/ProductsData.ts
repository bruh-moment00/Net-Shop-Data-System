import { http } from "../http";
import { BrandData } from "./BrandsData";
import { CategoryData } from "./CategoriesData";
import { ListDataWithPaging } from "./ListDataWithPaging";

export interface ProductData {
  id: number;
  category: string;
  brand: string;
  name: string;
  price: number;
  image: string;
}

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

export interface ProductDataForPost {
  categoryId: number;
  brandId: number;
  name: string;
  price: number;
  description: string;
  specString: string;
  imagePath: string;
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

export const getProducts = async (): Promise<ProductData[] | undefined> => {
  const result = await http<ListDataWithPaging>({
    path: `/Products`,
  });
  if (result.ok || result.body) {
    return result.body?.items;
  } else {
    return undefined;
  }
};

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

export const postProduct = async (
  product: ProductDataForPost
): Promise<ProductDataFull | undefined> => {
  const result = await http<ProductDataFullFromServer, ProductDataForPost>({
    path: "Products",
    method: "post",
    body: product,
  });
  if (result.ok && result.body) {
    return mapProductFullFromServer(result.body);
  } else {
    return undefined;
  }
};
