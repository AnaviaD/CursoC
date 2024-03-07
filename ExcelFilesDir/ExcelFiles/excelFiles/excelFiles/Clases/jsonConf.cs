using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excelFiles.Clases
{
    internal class jsonConf
    {
        public int Matches { get; set; }
        public List<string> listaHeaders { get; set; }
        public List<int> posiciones { get; set; }
        public int inicioHead { get; set; }
    }
}
