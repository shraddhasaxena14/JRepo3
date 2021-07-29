using System;
using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;


namespace MiniProject
{
    public partial class Program
    {

        void year(int year)
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            int UserDate = year;
            foreach (var cp in complaintslist)
            {
                if (cp.dateR.Year == UserDate)
                {
                    Console.WriteLine("Date Recieved: {0} | Product : {1} | Complaint ID: {2}", cp.dateR, cp.product, cp.ID);
                }
            }
        }

        void cname(string company)
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            string c = company;
            foreach (var cp in complaintslist)
            {
                if (cp.company.ToLower() == c.ToLower())
                {
                    Console.WriteLine("Date Recieved: {0} | Product : {1} | Complaint ID: {2}", cp.dateR, cp.product, cp.ID);
                }
            }

        }

        void cid(string id)
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            string cid1 = id;
            foreach (var cp in complaintslist)
            {
                if (cp.ID == cid1)
                {
                    Console.WriteLine("Date Recieved: {0} | Product : {1} | Complaint ID: {2}", cp.dateR, cp.product, cp.ID);
                }
            }

        }

        void daysclose()
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            foreach (var cp in complaintslist)
            {
                if (cp.cresponse.ToLower() != "in progress")
                {
                    TimeSpan timeSpan = cp.dateSC - cp.dateR;
                    Console.WriteLine("Number of days : {0}", timeSpan.Days);
                }
            }

        }

        void close()
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            foreach (var cp in complaintslist)
            {
                if (cp.cresponse == "Closed" || cp.cresponse == "Closed with explanation")
                {
                    Console.WriteLine("Date Recieved: {0} | Product : {1} | Complaint ID: {2} | Response: {3}", cp.dateR, cp.product, cp.ID, cp.cresponse);
                }
            }
        }

        void timely()
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            foreach (var cp in complaintslist)
            {
                if (cp.tr.ToLower() == "yes")
                {
                    Console.WriteLine("Date Recieved: {0} | Product : {1} | Complaint ID: {2} ", cp.dateR, cp.product, cp.ID);

                }
            }

        }
        void reg()
        {
            List<ComplaintList> complaintslist = new List<ComplaintList>();
            Program program = new Program();
            complaintslist = program.complaints();
            
            using (var streamwriter = new StreamWriter(@"C:\LTI training docs\complaints.csv"))
            {
                using (var csvWriter = new CsvWriter(streamwriter, CultureInfo.InvariantCulture))
                {
                    ComplaintList Addcomplaint = new ComplaintList();
                    Console.WriteLine("Enter the date recieved");
                    Addcomplaint.dateR = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the Product");
                    Addcomplaint.product = (Console.ReadLine());
                    Console.WriteLine("Enter the Sub-Product");
                    Addcomplaint.sproduct = (Console.ReadLine());
                    Console.WriteLine("Enter the Issue");
                    Addcomplaint.issue = (Console.ReadLine());
                    Console.WriteLine("Enter the Sub-Issue");
                    Addcomplaint.sissue = (Console.ReadLine());
                    Console.WriteLine("Enter the Company/Bank");
                    Addcomplaint.company = (Console.ReadLine());
                    Console.WriteLine("Enter the State");
                    Addcomplaint.state = (Console.ReadLine());
                    Console.WriteLine("Enter the ZIP Code");
                    Addcomplaint.zipcode = (Console.ReadLine());
                    Console.WriteLine("Enter the submitted via");
                    Addcomplaint.submitted = (Console.ReadLine());
                    Console.WriteLine("Enter the Date sent to the company");
                    Addcomplaint.dateSC = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the Respone");
                    Addcomplaint.cresponse = (Console.ReadLine());
                    Console.WriteLine("Timely response?");
                    Addcomplaint.tr = (Console.ReadLine());
                    Console.WriteLine("Consumer disputed?");
                    Addcomplaint.cd = (Console.ReadLine());
                    Console.WriteLine("Complaint ID?");
                    Addcomplaint.ID = Console.ReadLine();
                    complaintslist.Add(Addcomplaint);
                    csvWriter.WriteRecords(complaintslist);

                }
            }
        }
    }
}

