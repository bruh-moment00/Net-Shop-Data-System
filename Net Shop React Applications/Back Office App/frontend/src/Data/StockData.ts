import { OrderData } from "./OrdersData";
import { ProductDataFull } from "./ProductsData";
import { StockStatusData } from "./StockStatusData";

export interface StockData {
  Id: number;
  Product: ProductDataFull;
  StatusId: StockStatusData;
  ReceiptDate: Date;
  SellDate?: Date;
  Order?: OrderData;
}

export interface StockDataFromServer {
  Id: number;
  ProductName: string;
  Status: string;
  ReceiptDate: Date;
  SellDate?: Date;
  OrderId?: number;
}
