import { Role } from "./RolesData";

export interface Employee {
  Id: number;
  FirstName: string;
  SecondName?: string;
  LastName: string;
  Phone: string;
  Role: Role;
}
