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
        public int textOnlyChar;
        [LoadColumn(4)]
        public int textCharsMin;
        [LoadColumn(5)]
        public int textCharsMay;
        [LoadColumn(6)]
        public int textWhiteSpaces;
        [LoadColumn(7)]
        public int textDotSpaces;
        [LoadColumn(8)]
        public string label;
    }
}
