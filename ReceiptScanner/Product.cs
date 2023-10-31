
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    class Product
    {
        [JsonPropertyName("name"), JsonRequired]
        public string Name { get; set; }

        [JsonPropertyName("domestic"), JsonRequired]
        public bool Domestic { get; set; }

        [JsonPropertyName("price"), JsonRequired]
        public double Price { get; set; }

        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [JsonPropertyName("description"), JsonRequired]
        public string Description { get; set; }

        public string GetProductString()
        {

            string WeightFormat = Weight > 0 ? Weight.ToString()+"g" : "N/A"; 
            return String.Format("...{0}\nPrice: ${1:0.00}\n{2}...\nWeight: {3}", Name, Price, Description.Substring(0, 10), WeightFormat);

        }
    }
}
