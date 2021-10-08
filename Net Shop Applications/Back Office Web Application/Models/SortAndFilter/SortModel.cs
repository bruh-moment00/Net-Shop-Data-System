using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_Web_Application.Models.SortAndFilter
{
    public static class SortModel
    {
        public static IQueryable<Product> SortUpBy(this IQueryable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "brand":
                    products = products.OrderBy(s => s.Brand.Brand1);
                    break;
                case "price":
                    products = products.OrderBy(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Id);
                    break;
            }
            return products;
        }

        public static IQueryable<Product> SortDownBy(this IQueryable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "brand":
                    products = products.OrderByDescending(s => s.Brand.Brand1);
                    break;
                case "price":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                
            }
            return products;
        }

        public static IQueryable<StockList> SortUpBy(this IQueryable<StockList> stockList, string sortOrder)
        {
            switch (sortOrder)
            {
                case "receipt_date":
                    stockList = stockList.OrderBy(s => s.ReceiptDate);
                    break;
                case "sell_date":
                    stockList = stockList.OrderBy(s => s.SellDate);
                    break;
                case "product":
                    stockList = stockList.OrderBy(s => s.Product.Name);
                    break;
                case "status":
                    stockList = stockList.OrderBy(s => s.Status.Id);
                    break;
                default:
                    stockList = stockList.OrderBy(s => s.Id);
                    break;

            }
            return stockList;
        }

        public static IQueryable<StockList> SortDownBy(this IQueryable<StockList> stockList, string sortOrder)
        {
            switch (sortOrder)
            {
                case "receipt_date":
                    stockList = stockList.OrderByDescending(s => s.ReceiptDate);
                    break;
                case "sell_date":
                    stockList = stockList.OrderByDescending(s => s.SellDate);
                    break;
                case "product":
                    stockList = stockList.OrderByDescending(s => s.Product.Name);
                    break;
                case "status":
                    stockList = stockList.OrderByDescending(s => s.Status.Id);
                    break;
                default:
                    stockList = stockList.OrderByDescending(s => s.Id);
                    break;
            }
            return stockList;
        }

        public static IQueryable<Order> SortUpBy(this IQueryable<Order> orders, string sortOrder)
        {
            switch (sortOrder)
            {
                case "update_date":
                    orders = orders.OrderBy(s => s.UpdateDate);
                    break;
                case "status":
                    orders = orders.OrderBy(s => s.Status);
                    break;
                case "manager":
                    orders = orders.OrderBy(s => s.Manager.Id);
                    break;
                default:
                    orders = orders.OrderBy(s => s.Id);
                    break;
            }
            return orders;
        }

        public static IQueryable<Order> SortDownBy(this IQueryable<Order> orders, string sortOrder)
        {
            switch (sortOrder)
            {
                case "update_date":
                    orders = orders.OrderByDescending(s => s.UpdateDate);
                    break;
                case "status":
                    orders = orders.OrderByDescending(s => s.Status);
                    break;
                case "manager":
                    orders = orders.OrderByDescending(s => s.Manager.Id);
                    break;
                default:
                    orders = orders.OrderByDescending(s => s.Id);
                    break;
            }
            return orders;
        }

        public static IQueryable<UsersEmployees> SortUpBy(this IQueryable<UsersEmployees> employees, string sortOrder)
        {
            switch (sortOrder)
            {
                case "second_name":
                    employees = employees.OrderBy(s => s.SecondName);
                    break;
                case "last_name":
                    employees = employees.OrderBy(s => s.LastName);
                    break;
                case "role":
                    employees = employees.OrderBy(s => s.Role);
                    break;
                case "email":
                    employees = employees.OrderBy(s => s.IdNavigation.Email);
                    break;
                default:
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
            }
            return employees;
        }

        public static IQueryable<UsersEmployees> SortDownBy(this IQueryable<UsersEmployees> employees, string sortOrder)
        {
            switch (sortOrder)
            {
                case "second_name":
                    employees = employees.OrderByDescending(s => s.SecondName);
                    break;
                case "last_name":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                case "role":
                    employees = employees.OrderByDescending(s => s.Role);
                    break;
                case "email":
                    employees = employees.OrderByDescending(s => s.IdNavigation.Email);
                    break;
                default:
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;
            }
            return employees;
        }
    }
}
