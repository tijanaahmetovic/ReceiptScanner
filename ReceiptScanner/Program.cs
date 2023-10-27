using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReceiptScanner
{
class Program
    {
        static HttpClient client = new HttpClient();
        static string path = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

        static async Task<List<Product>> GetProductAsync()
        {
            List<Product> products = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            }
            return products;
        }


        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
        static async Task RunAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                List<Product> products = await GetProductAsync();
                Receipt receipt = new Receipt(products);
                receipt.PrintReceipt();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
