using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excelFiles.Clases
{
    internal class mercanciaGenerica
    {
        public int ReferenciaDelServicio { get; set; }
        public int RSdelRemitente { get; set; }
        public int RFCdelRemitente { get; set; }
        public int Supplier { get; set; }
        public int Calle { get; set; }
        public int Municipio { get; set; }
        public int Estado { get; set; }
        public int Pais { get; set; }
        public int CP { get; set; }
        public int RSdelDestinatario { get; set; }
        public int RFCDestinatario { get; set; }
        public int Calle2 { get; set; }
        public int Municipio2 { get; set; }
        public int Estado2 { get; set; }
        public int Pais2 { get; set; }
        public int CP2 { get; set; }
        public int PesoNeto { get; set; }
        public int NumeroTotalMercancias { get; set; }
        public int ClaveDelBienTransportado { get; set; }
        public int DescripcionDelBienTransportado { get; set; }
        public int ClaveUnidadDeMedida { get; set; }
        public int MaterialPeligroso { get; set; }
        public int FraccionArancelaria { get; set; }
        public int ValorDeLaMercancia { get; set; }
        public int TipoDeMoneda { get; set; }
    }
}
