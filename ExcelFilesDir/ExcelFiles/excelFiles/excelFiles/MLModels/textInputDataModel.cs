using Microsoft.ML.Data;


namespace excelFiles.MLModels
{
    internal class textInputDataModel
    {
        [LoadColumn(0)]
        public int textTotalLength;
        [LoadColumn(1)]
        public int textKind;
        [LoadColumn(2)]
        public int textNumbers;
        [LoadColumn(3)]
        public int textCharsMin;
        [LoadColumn(4)]
        public int textCharsMay;
        [LoadColumn(5)]
        public int textWhiteSpaces;
        [LoadColumn(6)]
        public string label;
    }
}
