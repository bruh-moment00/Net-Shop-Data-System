import { Brand } from "./BrandsData";
import { Category } from "./CategoriesData";

export interface Product {
  Id: number;
  Category: Category;
  Brand: Brand;
  Name: string;
  Price: number;
  Description: string;
  Specs: JSON;
  ImagePath: string;
}
