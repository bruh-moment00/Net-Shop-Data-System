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
export interface ProductDataWithPaging extends ListDataWithPaging {
  items: ProductData[];
}
export interface ProductDataFull {
  id: number;
  category: CategoryData;
  brand: BrandData;
  name: string;
  price: number;
  description: string;
  specs: string;
  image: string;
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
  id: product.id,
  category: {
    id: product.category.id,
    name: product.category.name,
  },
  brand: {
    id: product.brand.id,
    name: product.brand.brand1,
  },
  name: product.name,
  price: product.price,
  description: product.description,
  specs: product.specs,
  image: product.image,
});

export const getProducts = async (
  params: URLSearchParams
): Promise<ProductDataWithPaging | undefined> => {
  const result = await http<ProductDataWithPaging>({
    path: `/Products?${params.toString()}`,
  });
  if (result.ok || result.body) {
    return result.body;
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
