using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoEgipto.Models
{
    internal class Account
    {
        public string AccountId { get; set; }
        public List<CurrencyBalance> Balances { get; set; }
        public List<Order> Orders { get; set; }
    }
}
