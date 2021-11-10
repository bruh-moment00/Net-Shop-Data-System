import { Client } from "./ClientsData";
import { Employee } from "./EmployeesData";
import { OrderStatus } from "./OrderStatusData";

export interface Order {
  Id: number;
  Client: Client;
  Status: OrderStatus;
  UpdateDate: Date;
  Cost: number;
  Manager: Employee;
}
