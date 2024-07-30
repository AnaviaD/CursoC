using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoEgipto.Models
{
    internal class TradingPair
    {
        public Currency BaseCurrency { get; set; }
        public Currency QuoteCurrency { get; set; }
        public string Symbol { get; set; }
    }
}
