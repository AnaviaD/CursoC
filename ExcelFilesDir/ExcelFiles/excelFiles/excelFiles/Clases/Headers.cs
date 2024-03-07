using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excelFiles.Clases
{
    public static class Headers
    {
        private static readonly List<string> DHL_headers = new List<string>
        {
            "EMBARQUE_DHL",
            "IDORIGEN",
            "RFCREMITENTE",
            "CALLE",
            "MUNICIPIO",
            "MUNICIPIO_SAT",
            "ESTADO",
            "ESTADO_SAT",
            "PAIS",
            "CODIGOPOSTAL",
            "IDDESTINO",
            "RFCDESTINATARIO",
            "CALLE2",
            "MUNICIPIO2",
            "MUNICIPIO_SAT2",
            "ESTADO2",
            "ESTADO_SAT2",
            "PAIS2",
            "CODIGOPOSTAL2",
            "PESONETOTOTAL",
            "NUMTOTALMERCANCIAS",
            "BIENESTRANSP",
            "DESCRIPCION",
            "CLAVEUNIDAD",
            "MATERIALPELIGROSO",
            "CVEMATERIALPELIGROSO",
            "EMBALAJE",
            "DESCRIPEMBALAJE",
            "VALORMERCANCIA",
            "TOTAL_KM_RUTA",
            "FRACCIONARANCELARIA",
            "FRACCIONARANCELARIA2",
            "UUIDCOMERCIOEXT",
            "UUIDCOMERCIOEXT2",
            "SERVPROV_ID",
            "SERVPROV_NAME"
        };


        public static List<string> DHL_H
        {
            get { return DHL_headers; }
        }

    }
}
