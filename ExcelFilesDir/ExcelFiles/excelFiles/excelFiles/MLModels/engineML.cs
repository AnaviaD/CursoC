using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;

namespace excelFiles.MLModels
{
    public class engineML
    {
        //Aqui vamos a guardar el modelo
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Model.zip");

        public void startEngine()
        {
            MLContext mlContext = new MLContext();

            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<textInputDataModel>(path: "merchData.csv", hasHeader: false, separatorChar: ',');

            string featuresColumnName = "Features";

            var dataPreparationPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate(featuresColumnName, "textTotalLength", "textKind", "textNumbers", "textOnlyChar", "textCharsMin", "textCharsMay", "textWhiteSpaces", "textDotSpaces"))
                .AppendCacheCheckpoint(mlContext);

            var naiveBayesMultiClassTrainer = dataPreparationPipeline.Append(mlContext.MulticlassClassification.Trainers.NaiveBayes(labelColumnName: "Label", featureColumnName: featuresColumnName))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            TrainTestData trainTest = mlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            //Este es el modelo que utilizaremos
            var model = naiveBayesMultiClassTrainer.Fit(trainTest.TrainSet);

            var metrics = mlContext.MulticlassClassification.Evaluate(model.Transform(trainTest.TestSet));

            Console.WriteLine();
            Console.WriteLine("             Detector datos Mercancia machine learning      ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"    Confusion Matrix:   {metrics.ConfusionMatrix.GetFormattedConfusionTable().ToString()}");
            Console.WriteLine();
            Console.WriteLine($"    Macro Accuaracy:    {metrics.MacroAccuracy:P2}");
            Console.WriteLine($"    Micro Accuaracy:    {metrics.MicroAccuracy:P2}");
            Console.WriteLine();
            Console.WriteLine($"    Log Loss:           {metrics.LogLoss.ToString()}");
            Console.WriteLine($"    Log Loss Reduction: {metrics.LogLossReduction}");
            Console.WriteLine();
            Console.WriteLine($"    Top K Accuaracy:    {metrics.TopKAccuracy:P2}");
            Console.WriteLine($"    Log Loss Reduction: {metrics.TopKPredictionCount}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            //Aqui daremos nuesto string al que queremos analizar
            //12,2,7,5,0,5,0,0,RFC
            //Es importante recordar que el orden de las columnas lo es todo para la prediccion
            textInputDataModel datoMerch = new textInputDataModel()
            {
                textTotalLength =12,
                textKind        =2,
                textNumbers     =7,
                textOnlyChar    =5,
                textCharsMin    =0,
                textCharsMay    =5,
                textWhiteSpaces =0,
                textDotSpaces   =0
            };

            var predictor = mlContext.Model.CreatePredictionEngine<textInputDataModel, textOutputDataModel>(model);

            //Dandole el objeto a predecir
            var predictedClassOfFlower = predictor.Predict(datoMerch);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"     Campo : {string.Join("", predictedClassOfFlower.PredictedLabels.ToString())} ");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");

            using(var filestream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, trainingDataView.Schema, filestream);
                Console.WriteLine();
                Console.WriteLine("El modelo se guardo con exito");
                Console.WriteLine("Fin");

            }


        }
    }
}