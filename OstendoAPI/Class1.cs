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
    public class OstendoAPI
    {
        private HttpClient client = new HttpClient();
        private string returned = "";
        public OstendoAPI()
        {
            client.BaseAddress = new Uri("http://Ostendo.ddns.net:235");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }
        public OstendoAPI(string URL,string port)
        {
            client.BaseAddress = new Uri(URL+":"+port);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }
        public async Task<HttpResponseMessage> GetTransferInfo(string id)
        {
            string controller = "tabledata";
            string tableParam = "&tablename=inventorytransfers&format=json&condition=transferno='" + id + "'";

            HttpResponseMessage response = await client.GetAsync("/" + controller + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0" + tableParam);

            return response;
        }
        public async Task<HttpResponseMessage> GetTransferItems(string id)
        {
            string controller = "tabledata";
            string tableParam = "&tablename=inventorytransitems&format=json&condition=transferno='" + id + "'";

            HttpResponseMessage response = await client.GetAsync("/" + controller + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0" + tableParam);

            return response;
        }
        public async Task<HttpResponseMessage> GetTransferLines(string id)
        {
            string controller = "tabledata";
            string tableParam = "&tablename=inventorytranslines&format=json&condition=transferno='" + id + "'";

            HttpResponseMessage response = await client.GetAsync("/" + controller + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0" + tableParam);

            return response;
        }
        public async Task<HttpResponseMessage> PostInventoryTransfer(int transferno, string transferreference, string allocationmethod, string transferstyle)
        {

            string controller = "tabledata";
            string tableParam = "&tablename=inventorytransfers&keyfield=transferno&format=xml";
            string contentString = "";
            inventorytransfers invTransfer = new inventorytransfers();

            //  ---  Fill in Inventory Transfer Details HARD CODED -- //
            invTransfer.transferno = transferno;
            invTransfer.transferreference = transferreference;
            //invTransfer.TRANSFERDATE = DateTime.Today.AddDays(-1).GetDateTimeFormats("dd/MM/yyyy");
            //invTransfer.TRANSFERCHARGE = true;
            invTransfer.allocationmethod = allocationmethod;
            invTransfer.transferstyle = transferstyle;
            //invTransfer.CREATEFROM = "Automatic";
            // -- END OF FILL IN --  //

            //// Serialize / Make XML
            contentString = CreateXML(invTransfer);
            contentString = contentXMLAdjustments(contentString);
            //DEBUG THE XML CREATED FROM OBJECT IN HERE
            //Console.WriteLine("\n\n This is the contentString?");
            //Console.WriteLine(contentString);
            //Console.WriteLine("\n\n Should we continue?");
            //Console.ReadLine();

            var content = new StringContent(contentString, Encoding.UTF8, "application/xml");

            HttpResponseMessage response = await client.PostAsync("/" + controller + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0" + tableParam, content);

            return response;
        }

        public async Task<HttpResponseMessage> PostInventoryTransferLines(int transferno, string itemcode, double transferqty, double sysuniqueid)
        {

            string controller = "tabledata";
            string tableParam = "&tablename=inventorytransfers&keyfield=sysuniqueid&format=xml";
            string contentString = "";
            inventorytransferlines invTransferLines = new inventorytransferlines();

            //  ---  Fill in Inventory Transfer Details HARD CODED -- //
            invTransferLines.transferno = transferno;
            invTransferLines.itemcode = itemcode;
            invTransferLines.transferqty = transferqty;
            invTransferLines.sysuniqueid = sysuniqueid;
            // -- END OF FILL IN --  //

            //// Serialize / Make XML
            contentString = CreateXML(invTransferLines);
            contentString = contentXMLAdjustments(contentString);
            //DEBUG THE XML CREATED FROM OBJECT IN HERE
            Console.WriteLine("\n\n This is the contentString?");
            Console.WriteLine(contentString);
            Console.WriteLine("\n\n Should we continue?");
            Console.ReadLine();

            var content = new StringContent(contentString, Encoding.UTF8, "application/xml");

            HttpResponseMessage response = await client.PostAsync("/" + controller + "?apikey=Ytm1VIhM2ai7fewNDR1FuJ8cJx4OCPQOAD95Dn94ih4pM00ClrQXfFUAAbnlMFVmCkCo4ZbWoD48196cwaZyzT0pbln270loYHHjC2tQ7fz5sg%3D%3D&configuration=0" + tableParam, content);

            return response;
        }

        private static string CreateXML(Object YourClassObject)
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
    }
}
