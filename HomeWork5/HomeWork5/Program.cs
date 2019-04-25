using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet("ShopDB");

            DataTable orders = new DataTable("Orders");
            DataTable customers = new DataTable("Customers");
            DataTable employees = new DataTable("Employees");
            DataTable orderDetails = new DataTable("OrderDetails");
            DataTable products = new DataTable("Products");

            customers.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1, 
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            customers.Columns.Add("Name", typeof(string));

            employees.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            employees.Columns.Add("Name", typeof(string));
            
            products.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            products.Columns.Add("Name", typeof(string));

            orders.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            orders.Columns.Add("customerId", typeof(int));
            orders.Columns.Add("productId", typeof(int));
            orders.Columns.Add("employeeId", typeof(int));

            orderDetails.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            orderDetails.Columns.Add("orderId", typeof(int));
            orderDetails.Columns.Add("date", typeof(DateTime));
            orderDetails.Columns.Add("description", typeof(string));

            shopDB.Tables.Add(orders);
            shopDB.Tables.Add(customers);
            shopDB.Tables.Add(employees);
            shopDB.Tables.Add(products);
            shopDB.Tables.Add(orderDetails);

            shopDB.Relations.Add(new DataRelation
                ("fk_orders_customers", shopDB.Tables["Orders"].Columns["customerId"], shopDB.Tables["Customers"].Columns["Id"]));
            shopDB.Relations.Add(new DataRelation
                ("fk_orders_products", shopDB.Tables["Orders"].Columns["productId"], shopDB.Tables["Products"].Columns["Id"]));
            shopDB.Relations.Add(new DataRelation
                ("fk_orders_employees", shopDB.Tables["Orders"].Columns["employeeId"], shopDB.Tables["Employees"].Columns["Id"]));
            shopDB.Relations.Add(new DataRelation
                ("fk_orderdetails_orders", shopDB.Tables["OrderDetails"].Columns["orderId"], shopDB.Tables["Orders"].Columns["Id"]));


        }
    }
}
