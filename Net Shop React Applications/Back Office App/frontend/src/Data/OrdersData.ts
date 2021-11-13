import { ClientData } from "./ClientsData";
import { EmployeeData } from "./EmployeesData";
import { OrderStatusData } from "./OrderStatusData";

export interface OrderData {
  Id: number;
  Client: ClientData;
  Status: OrderStatusData;
  UpdateDate: Date;
  Cost: number;
  Manager: EmployeeData;
}
