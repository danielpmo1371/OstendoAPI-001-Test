using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp2
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
            Console.WriteLine("System initialized! Consuling API after you press Enter...");
            Console.ReadLine();
            returned = await ReachAPI(client, returned);
            Console.WriteLine(returned);
            Console.ReadLine();
        }
        private static async Task<string> ReachAPI(HttpClient client, string returned)
        {
            HttpResponseMessage response = await client.GetAsync("/assemblyorder/WO1563?apikey=Ytm1VIhM2ai7fewNDR1zCV%2Btfijsk5hoYcM%2FZaaCuFwm4PCPM%2BUwBcNw9yE%2BZjT35Uf8%2BAog%2FGbOCbosjMEOyFYTHDgEGZHgJT4xxwbVnu%2BymJs%3D&configuration=0");
            if (response.IsSuccessStatusCode)
            {
                //product = await response.Content.ReadAsAsync<AssemblyIssue>();
                returned = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API Consulted and answered successfully! Press Enter to see the result...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("API Consulted and answered a non successfull code! Press Enter to see the result...");

            }

            return returned;
        }
    }
}
