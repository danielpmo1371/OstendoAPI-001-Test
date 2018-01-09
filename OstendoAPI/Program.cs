﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OstendoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Press Enter to continue..");
            Console.ReadLine();
            GetList().Wait();
        }
        private static async Task GetList()
        {
            HttpClient client = new HttpClient();
            string returned = null;
            client.BaseAddress = new Uri("http://Ostendo.ddns.net:235");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            Console.WriteLine("System initialized! I'll ask you what you want from the API after you press Enter...");
            Console.ReadLine();
            returned = await ReachAPI(client, returned);
            Console.WriteLine(returned);
            Console.WriteLine("   ------   -----   ------  \n Test Finished. Press Enter to close application...");
            Console.ReadLine();
        }
        private static async Task<string> ReachAPI(HttpClient client, string returned)
        {
            //string controller = "assemblyorder";
            //string id = "/WO1563";
            string controller = "tabledata";
            string id = "";
            string tableParam = "&tablename=standardunits&format=xml";
            Console.WriteLine("What controller do you want to use?");
            controller = Console.ReadLine();
            Console.WriteLine("What id do you want to use? If you want a table, leave it blank");
            id = "/"+Console.ReadLine();
            Console.WriteLine("If you want a table, what's the table name?");
            tableParam = Console.ReadLine();
            if (tableParam != "") { tableParam = "&tablename=" + tableParam + "&format=xml"; }
            
            HttpResponseMessage response = await client.GetAsync("/"+controller+id+"?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0"+tableParam);
            if (response.IsSuccessStatusCode)
            {
                //product = await response.Content.ReadAsAsync<AssemblyIssue>();
                returned = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API Consulted and answered successfully! Press Enter to see the result...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("API Consulted and answered an ERROR code! Press Enter to see the result...");

            }

            return returned;
        }
    }
}
