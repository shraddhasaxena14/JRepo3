using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //1. Installation Required

namespace PrjAdo.Net
{
    class Shipper
    {
        public int ShipperID { get; set; }
        public string? Companyname { get; set; }
        public string? PhoneNo { get; set; }

        #region GetShipper
        public void GetShipper()
        {
            Console.WriteLine("Enter the Shipper Name or Company Name:");
            Companyname = Console.ReadLine();
            Console.WriteLine("Enter the Phone No.:");
            PhoneNo = Console.ReadLine();
        }
        #endregion

        public void LooseShipper()
        {
            Console.WriteLine("Enter the Shipper Name or Company Name:");
            Companyname = Console.ReadLine();
        }

        public void EditShipper()
        {
            Console.WriteLine("Enter the Shipper ID:");
            ShipperID = Convert.ToInt32(Console.ReadLine());
            GetShipper();
        }

    }
    class ConnectedArchitectiureEg
    {
        static void Main()
        {
            //2. Create sqlconnection object
            SqlConnection? con = null;

            //creating command object
            SqlCommand? cmd = null;

            try
            {

                //3.Windows Authentication
                con = new SqlConnection(
                     "Data Source = LAPTOP-RNMMD49O; Initial Catalog = Northwind; Integrated Security = true");

                //Sql server authentication
                // con = new SqlConnection(
                // "Data Source= DESKTOP-U8J1M3C\\MSSQLSERVER01;Initial Catalog=Northwind;User ID=sa;Password=newuser123#");

                //4.
                con.Open();
                //creating object of shipper class
                Shipper shipper = new Shipper();
                //calling getshipper method
                //Insertion

                /*shipper.GetShipper();
                cmd = new SqlCommand("insert into Shippers(CompanyName,Phone) values(@cname,@phone)", con);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                cmd.Parameters.AddWithValue("@phone", shipper.PhoneNo);
                int i = cmd.ExecuteNonQuery(); //return int
                Console.WriteLine("No. of Rows Affected:{0}", i);*/

                //Deletion
                //calling LooseShipper method

                /*shipper.LooseShipper();
                cmd = new SqlCommand("delete from Shippers where CompanyName=@cname", con);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                int i = cmd.ExecuteNonQuery(); //return int
                Console.WriteLine("No. of Rows Affected:{0}", i);
                cmd.Parameters.Clear();*/

                //Select

                /*SqlDataReader dr;
                cmd = new SqlCommand("select * from Shippers", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    Console.WriteLine(dr["CompanyName"] + " " + dr["Phone"]);
                }*/

                //Update

                #region ShipperUpdate

                /*shipper.EditShipper();
                cmd = new SqlCommand("update Shippers set CompanyName=@cname,Phone=@phone where ShipperID=@id", con);
                cmd.Parameters.AddWithValue("@id", shipper.ShipperID);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                cmd.Parameters.AddWithValue("@phone", shipper.PhoneNo);

                int i = cmd.ExecuteNonQuery(); //return int
                Console.WriteLine("No. of Rows Affected:{0}", i);*/
                #endregion Update in Region table from Northwind Database

                //Scaler Value
                cmd = new SqlCommand("select count(ShipperID) from Shippers", con);
                Console.WriteLine("Total Shippers:{0}", Convert.ToInt32(cmd.ExecuteScalar()));

                /*int i = (int)cmd.ExecuteScalar();
                Console.WriteLine("Total Shippers:{0}", i);*/
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
}