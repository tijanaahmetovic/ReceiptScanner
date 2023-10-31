using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    class ReceiptRepo
    {

        static string path = "https://mocki.io/v1/29cf0412-8229-4d35-a61a-c64939b946f8 ";

        private HttpClient client;

        public async Task<List<Product>> GetProductAsync()
        {

            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            List<Product> products = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    products = JsonSerializer.Deserialize<List<Product>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }

            return products;

        }
    }
}
