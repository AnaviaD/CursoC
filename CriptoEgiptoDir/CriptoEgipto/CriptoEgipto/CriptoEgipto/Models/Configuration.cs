using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoEgipto.Models
{
    internal class Configuration
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string BaseUrl { get; set; }
        //public List<TradingLimit> TradingLimits { get; set; }
        public List<string> TradingPairs { get; set; }
    }
}
