import React from "react";
import { Page } from "../../LayoutComponents/Page";

import { useForm } from "react-hook-form";
import { postProduct } from "../../Data/ProductsData";
import {
  Form,
  FormCheck,
  FormControl,
  FormGroup,
  Button,
} from "react-bootstrap";
import { BrandData, getBrands } from "../../Data/BrandsData";

type FormData = {
  name: string;
  category: any;
  brand: any;
  price: number;
  description: string;
  specs: string;
  imagePath: string;
};

interface BrandsImport {
  data: BrandData[] | undefined;
}

export const AddProductPage = () => {
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
      categoryId: data.category,
      brandId: data.brand,
      name: data.name,
      price: data.price,
      description: data.description,
      specString: data.specs,
      imagePath: data.imagePath,
    });
    setSuccessfullySubmitted(result ? true : false);
  };

  const [brands, setBrands] = React.useState<BrandData[] | undefined>();
  const [brandsLoading, setBrandsLoading] = React.useState(true);

  React.useEffect(() => {
    let cancelled = false;
    const doGetBrands = async () => {
      const BrandsList = await getBrands();
      if (!cancelled) {
        setBrands(BrandsList);
        setBrandsLoading(false);
      }
    };
    doGetBrands();
    return () => {
      cancelled = true;
    };
  }, []);

  return (
    <Page title="Добавить товар">
      <form onSubmit={handleSubmit(submitForm)}>
        <fieldset>
          <FormGroup>
            <label className="control-label">Категория</label>
            <Form.Select>
              <option unselectable="on">Выберите категорию</option>
            </Form.Select>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Производитель</label>
            <Form.Select>
              <option unselectable="on">Выберите производителя</option>
              <option>
                <input type="text"></input>
              </option>
              {brandsLoading ? (
                <option>Загрузка...</option>
              ) : (
                brands!.map((brand) => (
                  <option key={brand.id}>{brand.name}</option>
                ))
              )}
            </Form.Select>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Наименование</label>
            <Form.Control></Form.Control>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Цена</label>
            <Form.Control></Form.Control>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Описание</label>
            <Form.Control as="textarea"></Form.Control>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Характеристики</label>
            <Form.Select></Form.Select>
          </FormGroup>
          <FormGroup>
            <label className="control-label">Изображение</label>
            <Form.Select></Form.Select>
          </FormGroup>
          <FormGroup>
            <Button type="submit">Добавить</Button>
          </FormGroup>
        </fieldset>
      </form>
    </Page>
  );
};
