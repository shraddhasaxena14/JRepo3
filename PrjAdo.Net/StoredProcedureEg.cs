using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 

namespace PrjAdo.Net
{
    class DataAccessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                 "Data Source = LAPTOP-RNMMD49O; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }

        //CProcedureWithoutParameters

        internal void CallTenMostExpensiveProducts()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("Ten Most Expensive Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        internal void CallCustOrdersOrders(string cid)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("CustOrdersOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", cid);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["OrderID"] + " " + dr["OrderDate"] + " " + dr["ShippedDate"]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }
    class StoredProcedureEg
    {
        static void Main()
        {
            DataAccessLayer spobject = new DataAccessLayer();
            Console.WriteLine("1. Ten Most Expensive Products \n2. Customers Orders");
            Console.WriteLine("Enter your Choice:");
            int Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    spobject.CallTenMostExpensiveProducts();
                    break;

                case 2:
                    Console.WriteLine("Enter the Customer ID:");
                    string cid = Console.ReadLine();
                    spobject.CallCustOrdersOrders(cid);
                    break;

            }
        }
    }
}
