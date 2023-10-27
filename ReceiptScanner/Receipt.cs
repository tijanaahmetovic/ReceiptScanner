using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    class Receipt
    {
        public Receipt(List<Product> products)
        {
            Products = new List<Product>(products);
        }

        public List<Product> Products { get; set; }

        public void PrintReceipt()
        {
            var groups = this.Products.GroupBy(p => p.Domestic).Select(group =>
                        new {
                            Domestic = group.Key,
                            Products = group.OrderBy(x => x.Name)
                        });
            foreach (var group in groups)
            {
                string domestic = group.Domestic ? "Domestic" : "Imported";
                Console.WriteLine("."+ domestic);
                foreach (var p in group.Products)
                {
                    Console.WriteLine(p.GetProductString());
                }
            }
            Console.WriteLine(String.Format("Domestic cost: ${0:0.00}",this.DomesticCost(true)));
            Console.WriteLine(String.Format("Imported cost: ${0:0.00}", this.DomesticCost(false)));
            Console.WriteLine("Domestic count: " + this.DomesticCount(true));
            Console.WriteLine("Imported count: " + this.DomesticCount(false));

        }
        public double DomesticCost(bool domestic)
        {
            return this.Products.Where(p => p.Domestic == domestic).Sum(p => p.Price);
        }
        public int DomesticCount(bool domestic)
        {
            return this.Products.Where(p => p.Domestic == domestic).Count();
        }
    }
}
