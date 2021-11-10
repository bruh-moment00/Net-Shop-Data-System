import { Order } from "./OrdersData";
import { Product } from "./ProductsData";
import { StockStatus } from "./StockStatusData";

export interface Stock {
  Id: number;
  Product: Product;
  StatusId: StockStatus;
  ReceiptDate: Date;
  SellDate?: Date;
  OrderId?: Order;
}
