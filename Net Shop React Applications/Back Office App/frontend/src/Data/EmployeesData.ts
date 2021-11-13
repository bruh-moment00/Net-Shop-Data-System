import { RoleData } from "./RolesData";

export interface EmployeeData {
  Id: number;
  FirstName: string;
  SecondName?: string;
  LastName: string;
  Phone: string;
  RoleData: RoleData;
}
