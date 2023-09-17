using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercambioAdmin.Clases
{
    public class EquipoTerminal
    {
        public string deviceId {get;set;}
        public string terminalId { get;set;}
        public string terminalName { get;set;}
        public string terminalType { get;set;}
        public DateTime terminalLastBackUp { get;set;}
    }
}
