using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PrjAdo.Net
{
    class DAL
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

        public void DisplayRegion()
        {
            try
            {
                con = GetConnection();
                SqlDataAdapter da = new SqlDataAdapter("select * from Region", con);
                DataSet ds = new DataSet(); //collection of tables
                                            //putting the table inside dataset
                da.Fill(ds, "NWREGION");

                //reading the table info from dataset

                DataTable dt = ds.Tables["NWREGION"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col]);
                        Console.Write(" ");
                    }
                    Console.WriteLine(" ");
                }
                // adding one more table to dataset : Shipper
                /* Console.WriteLine(" -------------");
                 Console.WriteLine(" -----Shipper Table--------");
                 da = new SqlDataAdapter("Select * from Shippers", con);
                 da.Fill(ds, "NWSHIPPERS");
                 DataTable dt1 = ds.Tables["NWSHIPPERS"];
                 foreach (DataRow row in dt1.Rows)
                 {
                     foreach (DataColumn col in dt1.Columns)
                     {
                         Console.Write(row[col]);
                         Console.Write(" ");
                     }
                     Console.WriteLine(" ");
                 } */



                // Insert,Update, delete operation
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Fill(ds);

                // Inserting or adding a new row
                //Creating a new row in NWREGION 
                DataRow row1 = ds.Tables["NWREGION"].NewRow();
                row1["RegionID"] = 11;
                row1["RegionDescription"] = "ashu";
                // Adding row to database in datasete
                ds.Tables["NWREGION"].Rows.Add(row1);

                da.Update(ds, "NWREGION");
                Console.WriteLine("------------");


                dt = ds.Tables["NWREGION"];
                foreach (DataRow Datarow in dt.Rows)
                {
                    foreach (DataColumn DataColumn in dt.Columns)
                    {
                        Console.Write(Datarow[DataColumn]);
                        Console.Write(" ");
                    }
                    Console.WriteLine(" ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }

        }

    }

    class DisconnectedArchitecture
    {
        static void Main()
        {
            DAL d = new DAL();
            d.DisplayRegion();
        }
    }
}
