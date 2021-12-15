import { http } from "../http";

export interface ListDataWithPaging {
  currentPage: number;
  totalPages: number;
  pageSize: number;
  totalCount: number;
  items: any[];
  hasPrevious: boolean;
  hasNext: boolean;
}
