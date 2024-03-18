using Microsoft.ML.Data;


namespace excelFiles.MLModels
{
    internal class textOutputDataModel
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
