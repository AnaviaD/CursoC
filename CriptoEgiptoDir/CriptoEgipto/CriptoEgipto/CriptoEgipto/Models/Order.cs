using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoEgipto.Models
{
    internal class Order
    {
        public string OrderId { get; set; }
        public string Symbol { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Status { get; set; }
    }
}
