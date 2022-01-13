import { EnumType } from "typescript";

export interface EmployeeData {
  Id: number;
  FirstName: string;
  SecondName?: string;
  LastName: string;
  Phone: string;
  Role: EnumType;
}
