using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;

namespace MiniProject
{
public partial class Program
{
       

        public List<ComplaintList> complaints()
        {
            using (var streamReader = new StreamReader(@"C:\LTI training docs\complaints.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<ComplaintList>().ToList();
                    return records;
                }
            }

        }
       public class ComplaintList
        {
            [Name("Date received")]
            public DateTime dateR { get; set; }
            [Name("Product")]
            public string product { get;  set; }
            [Name("Sub-product")]
            public string sproduct { get;  set; }
            [Name("Issue")]
            public string issue { get;  set; }
            [Name("Sub-issue")]
            public string sissue { get; set; }
            [Name("Company")]
            public string company { get;  set; }
            [Name("State")]
            public string state { get;  set; }
            [Name("ZIP code")]
            public string zipcode { get; set; }
            [Name("Submitted via")]
            public string submitted { get; set; }
            [Name("Date sent to company")]
            public DateTime dateSC { get; set; }
            [Name("Company response to consumer")]
            public string cresponse { get; set; }
            [Name("Timely response?")]
            public string tr { get;  set; }
            [Name("Consumer disputed?")]
            public string cd { get; set; }
            [Name("Complaint ID")]
            public string ID { get;  set; }





        }

       public static void Main(string[] args)
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();

            int i,ch;
            do
            {


                Console.WriteLine("WELCOME TO COMPLAINT LIST APPLICATION!");
                Console.WriteLine("1. View on the basis of Complaint received year");
                Console.WriteLine("2. View on the basis of Company/Bank name");
                Console.WriteLine("3. View on the basis of Complaint ID");
                Console.WriteLine("4. View number of days to close the complaint");
                Console.WriteLine("5. View all the complaints are closed");
                Console.WriteLine("6. View all the complaints that was timely responsed");
                Console.WriteLine("7. TO REGISTER NEW COMPLAINT ");
                Console.WriteLine("Choose the appropiate number");
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:

                        Console.WriteLine("Enter the year in which you want to see the complaint records: ");
                        int UserDate = Convert.ToInt32(Console.ReadLine());
                        program.year(UserDate);
                        break;

                    case 2:
                        Console.WriteLine("Enter the Company/Bank name: ");
                        string company = (Console.ReadLine());
                        program.cname(company);
                        break;

                    case 3:

                        Console.WriteLine("Enter the complaint ID: ");
                        string ID = (Console.ReadLine());
                        program.cid(ID);
                        break;
                    case 4:
                        program.daysclose();
                        break;

                    case 5:
                        program.close();
                        break;
                    case 6:
                        program.timely();
                        break;
                    case 7:
                        program.reg();
                        break;
                }
                Console.WriteLine("1:continue 0:exit ");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch != 0); 

       }
}
   
}
