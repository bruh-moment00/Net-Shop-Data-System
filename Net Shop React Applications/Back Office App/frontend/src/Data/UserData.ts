import { EnumType } from "typescript";

export interface User {
  email: string;
  firstName: string;
  secondName?: string;
  lastName: string;
  phone: string;
  role: EnumType;
}
