namespace excelFiles.Clases
{
    public static class Headers
    {
        private static List<string> REFERENCIA_DE_SERV_list         = new List<string> { "hola" };
        private static List<string> IDORIGEN_list                   = new List<string> { "IDORIGEN" };
        private static List<string> RFCREMITENTE_list               = new List<string> { "RFCREMITENTE" };
        private static List<string> CALLE_list                      = new List<string> { "CALLE" };
        private static List<string> MUNICIPIO_list                  = new List<string> { "MUNICIPIO" };
        private static List<string> MUNICIPIO_SAT_list              = new List<string> { "MUNICIPIO_SAT" };
        private static List<string> ESTADO_list                     = new List<string> { "ESTADO" };
        private static List<string> ESTADO_SAT_list                 = new List<string> { "ESTADO_SAT" };
        private static List<string> PAIS_list                       = new List<string> { "PAIS" };
        private static List<string> CODIGOPOSTAL_list               = new List<string> { "CODIGOPOSTAL" };
        private static List<string> IDDESTINO_list                  = new List<string> { "IDDESTINO" };
        private static List<string> RFCDESTINATARIO_list            = new List<string> { "RFCDESTINATARIO" };
        private static List<string> CALLE2_list                     = new List<string> { "CALLE2" };
        private static List<string> MUNICIPIO2_list                 = new List<string> { "MUNICIPIO2" };
        private static List<string> MUNICIPIO_SAT2_list             = new List<string> { "MUNICIPIO_SAT2" };
        private static List<string> ESTADO2_list                    = new List<string> { "ESTADO2" };
        private static List<string> ESTADO_SAT2_list                = new List<string> { "ESTADO_SAT2" };
        private static List<string> PAIS2_list                      = new List<string> { "PAIS2" };
        private static List<string> CODIGOPOSTAL2_list              = new List<string> { "CODIGOPOSTAL2" };
        private static List<string> PESONETOTOTAL_list              = new List<string> { "PESONETOTOTAL" };
        private static List<string> NUMTOTALMERCANCIAS_list         = new List<string> { "NUMTOTALMERCANCIAS" };
        private static List<string> BIENESTRANSP_list               = new List<string> { "BIENESTRANSP" };
        private static List<string> DESCRIPCION_list                = new List<string> { "DESCRIPCION" };
        private static List<string> CLAVEUNIDAD_list                = new List<string> { "CLAVEUNIDAD" };
        private static List<string> MATERIALPELIGROSO_list          = new List<string> { "MATERIALPELIGROSO" };
        private static List<string> CVEMATERIALPELIGROSO_list       = new List<string> { "CVEMATERIALPELIGROSO" };
        private static List<string> EMBALAJE_list                   = new List<string> { "EMBALAJE" };
        private static List<string> DESCRIPEMBALAJE_list            = new List<string> { "DESCRIPEMBALAJE" };
        private static List<string> VALORMERCANCIA_list             = new List<string> { "VALORMERCANCIA" };
        private static List<string> TOTAL_KM_RUTA_list              = new List<string> { "TOTAL_KM_RUTA" };
        private static List<string> FRACCIONARANCELARIA_list        = new List<string> { "FRACCIONARANCELARIA" };
        private static List<string> FRACCIONARANCELARIA2_list       = new List<string> { "FRACCIONARANCELARIA2" };
        private static List<string> UUIDCOMERCIOEXT_list            = new List<string> { "UUIDCOMERCIOEXT" };
        private static List<string> UUIDCOMERCIOEXT2_list           = new List<string> { "UUIDCOMERCIOEXT2" };
        private static List<string> SERVPROV_ID_list                = new List<string> { "SERVPROV_ID" };
        private static List<string> SERVPROV_NAM_list               = new List<string> { "SERVPROV_NAM" };

        private static List<List<string>> headersList = new List<List<string>>();

        static Headers()
        {
            headersList.Add(REFERENCIA_DE_SERV_list);
            headersList.Add(IDORIGEN_list);
            headersList.Add(RFCREMITENTE_list);
            headersList.Add(CALLE_list);
            headersList.Add(MUNICIPIO_list);
            headersList.Add(MUNICIPIO_SAT_list);
            headersList.Add(ESTADO_list);
            headersList.Add(ESTADO_SAT_list);
            headersList.Add(PAIS_list);
            headersList.Add(CODIGOPOSTAL_list);
            headersList.Add(IDDESTINO_list);
            headersList.Add(RFCDESTINATARIO_list);
            headersList.Add(CALLE2_list);
            headersList.Add(MUNICIPIO2_list);
            headersList.Add(MUNICIPIO_SAT2_list);
            headersList.Add(ESTADO2_list);
            headersList.Add(ESTADO_SAT2_list);
            headersList.Add(PAIS2_list);
            headersList.Add(CODIGOPOSTAL2_list);
            headersList.Add(PESONETOTOTAL_list);
            headersList.Add(NUMTOTALMERCANCIAS_list);
            headersList.Add(BIENESTRANSP_list);
            headersList.Add(DESCRIPCION_list);
            headersList.Add(CLAVEUNIDAD_list);
            headersList.Add(MATERIALPELIGROSO_list);
            headersList.Add(CVEMATERIALPELIGROSO_list);
            headersList.Add(EMBALAJE_list);
            headersList.Add(DESCRIPEMBALAJE_list);
            headersList.Add(VALORMERCANCIA_list);
            headersList.Add(TOTAL_KM_RUTA_list);
            headersList.Add(FRACCIONARANCELARIA_list);
            headersList.Add(FRACCIONARANCELARIA2_list);
            headersList.Add(UUIDCOMERCIOEXT_list);
            headersList.Add(UUIDCOMERCIOEXT2_list);
            headersList.Add(SERVPROV_ID_list);
            headersList.Add(SERVPROV_NAM_list);

        }

        public static List<List<string>> HeadList
        {
            get { return headersList; }
        }

    }
}
