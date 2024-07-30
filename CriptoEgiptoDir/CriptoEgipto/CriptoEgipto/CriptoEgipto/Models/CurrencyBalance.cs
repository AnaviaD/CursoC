using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoEgipto.Models
{
    internal class CurrencyBalance
    {
        public Currency Currency { get; set; }
        public decimal Free { get; set; }
        public decimal Locked { get; set; }
    }
}
