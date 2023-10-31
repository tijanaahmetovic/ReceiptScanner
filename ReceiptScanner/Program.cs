using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceiptScanner
{
class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var receiptRepo = new ReceiptRepo();
                List<Product> productList = receiptRepo.GetProductAsync().GetAwaiter().GetResult();
                Receipt receipt = new Receipt(productList);
                receipt.PrintReceipt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

             Console.ReadLine();
        }

    }
}
