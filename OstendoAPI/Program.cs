using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace OstendoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            OstendoAPI ostendoAPI = new OstendoAPI();
            Console.WriteLine("Hello World! Press Enter to continue..");
            Console.ReadLine();
            GetList(ostendoAPI).Wait();
        }
        private static async Task GetList(OstendoAPI ostendoAPI)
        {
            HttpClient client = new HttpClient();
            string returned = null;
            string method = "";
            client.BaseAddress = new Uri("http://Ostendo.ddns.net:235");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            while (!method.Equals("q"))
            {
                Console.WriteLine("System initialized! " +
                    "\n Press 1 for Get Method, " +
                    "\n 2 for Post Method, " +
                    "\n 3 for SQL, " +
                    "\n 4 to Get Transfer Info, " +
                    "\n 5 to Get Transfer Items" +
                    "\n 6 to Get Transfer Lines" +
                    "\n 7 to Post Inventory Trasfer, " +
                    "\n 8 to Post Inventory Trasfer Lines, " +

                    "\n 'm' to Execute minimal code for API" +
                    "\n 'q' to Quit");
                method = Console.ReadLine();
                if (method.Equals("1")){ returned = await ReachAPI(client, returned); }
                if (method.Equals("2")){ returned = await PostAPI(client, returned); }
                if (method.Equals("3")) { returned = await SQLAPI(client, returned); }
                if (method.Equals("4")) { returned = await GetTransferInformation(ostendoAPI, returned); }
                if (method.Equals("5")) { returned = await GetTransferItems(ostendoAPI, returned); }
                if (method.Equals("6")) { returned = await GetTransferLines(ostendoAPI, returned); }
                if (method.Equals("7")) { returned = await PostInventoryTransfer(ostendoAPI, returned); }
                if (method.Equals("8")) { returned = await PostInventoryTransferLines(ostendoAPI, returned); }

                // Minimal code to use API class to get a trasnfer info and stringfy the result
                if (method.Equals("m"))
                {
                    OstendoAPI minimalAPI = new OstendoAPI();
                    HttpResponseMessage responseFromMinimal = await minimalAPI.GetTransferInfo("8676");
                    returned = await responseFromMinimal.Content.ReadAsStringAsync();
                }
                //Quit or print
                if (method.Equals("q")) { Environment.Exit(0); }
                else
                {
                Console.WriteLine(returned);
                Console.WriteLine("   ------   -----   ------  \n Test Finished. Press Enter to close application...");
                Console.ReadLine();
                }
            }
        }

        private static async Task<string> GetTransferInformation(OstendoAPI ostendoAPI, string returned)
        {
            //Getting parameter from the user using console
            string id = "";
            Console.WriteLine("What's the Transfer Reference Number?");
            id = Console.ReadLine();

            //Getting the response from API
            HttpResponseMessage response = await ostendoAPI.GetTransferInfo(id);
            //Handling the response. In case successfull or fail it shows the correct message.
            returned = await CheckSuccessAndPostToUser(returned, response);

            //Returning the string for printing to console
            return returned;
        }
        private static async Task<string> GetTransferItems(OstendoAPI ostendoAPI, string returned)
        {
            //Getting parameter from the user using console
            string id = "";
            Console.WriteLine("What's the Transfer Reference Number?");
            id = Console.ReadLine();

            //Getting the response from API
            HttpResponseMessage response = await ostendoAPI.GetTransferItems(id);
            //Handling the response. In case successfull or fail it shows the correct message.
            returned = await CheckSuccessAndPostToUser(returned, response);

            //Returning the string for printing to console
            return returned;
        }
        private static async Task<string> GetTransferLines(OstendoAPI ostendoAPI, string returned)
        {
            //Getting parameter from the user using console
            string id = "";
            Console.WriteLine("What's the Transfer Reference Number?");
            id = Console.ReadLine();

            //Getting the response from API
            HttpResponseMessage response = await ostendoAPI.GetTransferLines(id);
            //Handling the response. In case successfull or fail it shows the correct message.
            returned = await CheckSuccessAndPostToUser(returned, response);

            //Returning the string for printing to console
            return returned;
        }

        private static async Task<string> ReachAPI(HttpClient client, string returned)
        {
            //string controller = "assemblyorder";
            //string id = "/WO1563";
            string controller = "tabledata";
            string id = "";
            string tableParam = "&tablename=inventorytransfers&format=xml&condition=transferno='8665'";
            //Console.WriteLine("What controller do you want to use?");
            //controller = Console.ReadLine();
            //Console.WriteLine("What id do you want to use? If you want a table, leave it blank");
            //id = "/"+Console.ReadLine();
            //Console.WriteLine("If you want a table, what's the table name?");
            //tableParam = Console.ReadLine();
            //if (tableParam != "") { tableParam = "&tablename=" + tableParam + "&format=xml"; }
            
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

            string controller = "";
            string id = "";
            string tableParam = "";


            //  -------- Working Example for Assembly Order ------- //
            controller = "assemblyorder";
            id = "";
            tableParam = "";
            var content = new StringContent("<assemblyorder><orderheader><ordernumber></ordernumber><orderdate>11/01/2018</orderdate><itemcode>F2125</itemcode><itemdescription>Whole Milk Powder 25kg Bag- China</itemdescription><itemunit>Kg</itemunit><requireddate>11/01/2018</requireddate><orderqty>4000</orderqty><orderline><ordernumber></ordernumber><stepname>Assembly</stepname><codetype>Item Code</codetype><linecode>M7030</linecode><linedescription>Asssembly of 02125</linedescription><lineunit>Ltr</lineunit><orderqty>9000</orderqty></orderline></orderheader></assemblyorder>", Encoding.UTF8, "application/xml");
            //  -------- Working Example for Assembly Order ------- //

            Console.WriteLine("\n\n This is the content of the message?");
            Console.WriteLine(await content.ReadAsStringAsync());
            Console.WriteLine("\n\n Should we continue?");
            Console.ReadLine();

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
        private static async Task<string> PostInventoryTransfer(OstendoAPI ostendoAPI, string returned)
        {
            //Getting Transfer Details from user via the console
            Console.WriteLine("Please type: 'transferno', 'trasnferreferenceno', 'allocationmethod', 'transferstyle'" +
                "\n Instructions: type only the data with no quotes and separate each field with comma");
            string transfer = Console.ReadLine();
            string[] transferfields = transfer.Split(",");
            //Confirming what the user typed
            Console.WriteLine("You typed:" +
                "\n transferno = " + transferfields[0] +
                "\n trasnferreferenceno = " + transferfields[1] +
                "\n allocationmethod = " + transferfields[2] +
                "\n transferstyle = " + transferfields[3]);

            //Getting the response from API
            HttpResponseMessage response = await ostendoAPI.PostInventoryTransfer(Int32.Parse(transferfields[0]), transferfields[1], transferfields[2], transferfields[3]);
            //Handling the response. In case successfull or fail it shows the correct message.
            returned = await CheckSuccessAndPostToUser(returned, response);

            return returned;
        }
        private static string PostInventoryTransferItem(HttpClient client, string returned)
        {
            returned = "API Implementation Not Available";

            return returned;
        }
        private static async Task<string> PostInventoryTransferLines(OstendoAPI ostendoAPI, string returned)
        {
            //Getting Transfer Details from user via the console
            Console.WriteLine("Please type: 'transferno', 'itemcode', 'transferqty', 'sysuniqueid'" +
                "\n Instructions: type only the data with no quotes and separate each field with comma");
            string transfer = Console.ReadLine();
            string[] transferfields = transfer.Split(",");
            //Confirming what the user typed
            Console.WriteLine("You typed:" +
                "\n transferno = " + transferfields[0] +
                "\n itemcode = " + transferfields[1] +
                "\n transferqty = " + transferfields[2] +
                "\n sysuniqueid = " + transferfields[3]
                );

            //Getting the response from API
            HttpResponseMessage response = await ostendoAPI.PostInventoryTransferLines(Int32.Parse(transferfields[0]), transferfields[1], Double.Parse(transferfields[2]), Double.Parse(transferfields[3]));
            //Handling the response. In case successfull or fail it shows the correct message.
            returned = await CheckSuccessAndPostToUser(returned, response);

            return returned;
        }

        private static async Task<string> CheckSuccessAndPostToUser(string returned, HttpResponseMessage response)
        {
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

        private static string contentXMLAdjustments(string contentString)
        {
            contentString = contentString.Replace("\"<?xml version=\"1.0\"?><InventoryTransfers xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "<InventoryTransfers>");
            contentString = contentString.Replace("<?xml version=", "");
            contentString = contentString.Replace("xmlns:xsi=", "");
            contentString = contentString.Replace("http://www.w3.org/2001/XMLSchema-instance", "");
            contentString = contentString.Replace("xmlns:xsd=", "");
            contentString = contentString.Replace("http://www.w3.org/2001/XMLSchema", "");
            contentString = contentString.Replace("?>", "");
            contentString = contentString.Replace("1.0", "");
            contentString = contentString.Replace("\"\"", "");
            contentString = contentString.Replace("  ", "");
            contentString = contentString.Insert(0, "<ostendoimport>");
            contentString = contentString.Insert(contentString.Length, "</ostendoimport>");
            //contentString = contentString.ToLower();
            return contentString;
        }

        public static string CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
                                                      // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }
    }
}
