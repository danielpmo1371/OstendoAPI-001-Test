using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("System initialized! Press 1 for Get Method, 2 for Post Method, 3 for SQL...");
            string method = Console.ReadLine();
            if (method.Equals("1")){ returned = await ReachAPI(client, returned); }
            if (method.Equals("2")){ returned = await PostAPI(client, returned); }
            if (method.Equals("3")) { returned = await SQLAPI(client, returned); }
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
                Console.WriteLine("API Consulted and answered successfully! Press Enter to check the result...");
                Console.ReadLine();
                if (returned.Contains("DanielPaivaMatosOliveira")) { Console.WriteLine("Post Method was Successfull"); }
                else Console.WriteLine("No signs of what was posted...Press Enter to see the results...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("API Consulted and answered an ERROR code! Press Enter to see the result...");

            }

            return returned;
        }
        private static async Task<string> PostAPI(HttpClient client, string returned)
        {

            string controller = "assemblyorder";
            string id = "";
            //string tableParam = "";

            //  -------- Working Example for Assembly Order ------- //
            var content = new StringContent("<assemblyorder><orderheader><ordernumber></ordernumber><orderdate>11/01/2018</orderdate><itemcode>F2125</itemcode><itemdescription>Whole Milk Powder 25kg Bag- China</itemdescription><itemunit>Kg</itemunit><requireddate>11/01/2018</requireddate><orderqty>4000</orderqty><orderline><ordernumber></ordernumber><stepname>Assembly</stepname><codetype>Item Code</codetype><linecode>M7030</linecode><linedescription>Asssembly of 02125</linedescription><lineunit>Ltr</lineunit><orderqty>9000</orderqty></orderline></orderheader></assemblyorder>", Encoding.UTF8, "application/xml");
            //  -------- Working Example for Assembly Order ------- //

            HttpResponseMessage response = await client.PostAsync("/" + controller + id + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0", content);
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
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return returned;
        }
        private static async Task<string> SQLAPI(HttpClient client, string returned)
        {

            string controller = "sqlquery";
            string id = "";
            //string tableParam = "";

            //  -------- Working Example for Assembly Order ------- //
            var content = new StringContent("select * from WAREHOUSEMASTER, INVENTORY, ITEMMASTER, LOCATIONMASTER where WAREHOUSEMASTER.WAREHOUSECODE = INVENTORY.WAREHOUSECODE and ITEMMASTER.ITEMCODE = INVENTORY.ITEMCODE and LOCATIONMASTER.LOCATIONCODE = INVENTORY.LOCATIONCODE and LOCATIONMASTER.WAREHOUSECODE = INVENTORY.WAREHOUSECODE order by SITEOREXTERNAL, SITENAME, INVENTORY.WAREHOUSECODE, INVENTORY.LOCATIONCODE, INVENTORY.ITEMCODE, INVENTORY.INVENTORYUNIT", Encoding.UTF8, "application/text");
            

            HttpResponseMessage response = await client.PostAsync("/" + controller + id + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&format=json&configuration=0", content);
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
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return returned;
        }
    }
}
