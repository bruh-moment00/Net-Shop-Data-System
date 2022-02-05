import { EnumType } from "typescript";
import { Role } from "./RolesData";

export interface User {
  email: string;
  firstName: string;
  secondName?: string;
  lastName: string;
  phone: string;
  role: Role;
}
