using excelFiles.Clases;
using Microsoft.ML;


namespace excelFiles.MLModels
{
    public class useModelEngine
    {
        analizadores filtro = new analizadores();

        public class MLData
        {
            public int textTotalLength { get; set; }
            public int textKind { get; set; }
            public int textNumbers { get; set; }
            public int textOnlyChar { get; set; }
            public int textCharsMin { get; set; }
            public int textCharsMay { get; set; }
            public int textWhiteSpaces { get; set; }
            public int textDotSpaces { get; set; }
            public string label { get; set; }
        }

        public string startPrediction(string txtPredict)
        {
            string modelPath = Path.Combine(Environment.CurrentDirectory, "Model.zip");

            MLContext mlContext = new MLContext();
            
            // Cargar el modelo desde el archivo
            var loadedModel = mlContext.Model.Load(modelPath, out var schema);


          
            // Utilizar el modelo cargado o creado
            var predictor = mlContext.Model.CreatePredictionEngine<textInputDataModel, textOutputDataModel>(loadedModel);
            textInputDataModel datoMerch = new textInputDataModel()
            {
                textTotalLength             = filtro.ContarCaracteres(txtPredict),
                textKind                    = filtro.TipoDeCadena(txtPredict),
                textNumbers                 = filtro.ContarDigitos(txtPredict),
                textOnlyChar                = filtro.ContarCaracteresExcluyendoNumeros(txtPredict),
                textCharsMin                = filtro.ContarLetrasMinusculas(txtPredict),
                textCharsMay                = filtro.ContarLetrasMayusculas(txtPredict),
                textWhiteSpaces             = filtro.ContarEspacios(txtPredict),
                textDotSpaces               = filtro.ContarPuntos(txtPredict),
            };


            var prediction = predictor.Predict(datoMerch);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"     Campo : {string.Join("", prediction.PredictedLabels.ToString())} ");
            Console.WriteLine();

            return prediction.PredictedLabels.ToString();
        }
    }
}
