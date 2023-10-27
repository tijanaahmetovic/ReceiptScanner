using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    class Product
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domestic")]
        public bool Domestic { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public string GetProductString()
        {
            string WeightFormat = Weight > 0 ? Weight.ToString()+"g" : "N/A"; 
            return String.Format("...{0}\nPrice: ${1:0.00}\n{2}...\nWeight: {3}", Name, Price, Description.Substring(0, 10), WeightFormat);
        }
    }
}
