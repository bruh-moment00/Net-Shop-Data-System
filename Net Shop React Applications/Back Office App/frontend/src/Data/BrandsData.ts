import { http } from "../http";

export interface BrandData {
  Id: number;
  Name: string;
}

export const getBrands = async (): Promise<BrandData[] | undefined> => {
  const result = await http<BrandData[]>({
    path: `/Brands`,
  });
  if (result.ok || result.body) {
    return result.body;
  } else {
    return [];
  }
};
