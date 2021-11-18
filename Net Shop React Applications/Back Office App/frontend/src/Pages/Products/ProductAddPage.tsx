import React from "react";

import { useForm } from "react-hook-form";

import { BrandData } from "../../Data/BrandsData";
import { CategoryData } from "../../Data/CategoriesData";
import { postProduct } from "../../Data/ProductsData";
import { Page } from "../../LayoutComponents/Page";

type FormData = {
  category: CategoryData;
  brand: BrandData;
  name: string;
  price: number;
  description: string;
  specString: string;
  imagePath: string;
};

export const ProductAddPage = () => {
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);

  const {
    register,
    formState: { errors, isSubmitting },
    handleSubmit,
  } = useForm<FormData>({
    mode: "onBlur",
  });

  const submitForm = async (data: FormData) => {
    const result = await postProduct({
      categoryId: data.category.Id,
      brandId: data.brand.Id,
      name: data.name,
      price: data.price,
      description: data.description,
      specString: data.specString,
      imagePath: data.imagePath,
    });
    setSuccessfullySubmitted(result ? true : false);
  };

  return (
    <Page>
      <form onSubmit={handleSubmit(submitForm)}></form>
    </Page>
  );
};
