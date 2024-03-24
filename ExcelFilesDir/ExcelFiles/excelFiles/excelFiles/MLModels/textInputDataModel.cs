using Microsoft.ML.Data;


namespace excelFiles.MLModels
{
    internal class textInputDataModel
    {
        [LoadColumn(0)]
        public float textTotalLength;
        [LoadColumn(1)]
        public float textKind;
        [LoadColumn(2)]
        public float textNumbers;
        [LoadColumn(3)]
        public float textOnlyChar;
        [LoadColumn(4)]
        public float textCharsMin;
        [LoadColumn(5)]
        public float textCharsMay;
        [LoadColumn(6)]
        public float textWhiteSpaces;
        [LoadColumn(7)]
        public float textDotSpaces;
        [LoadColumn(8)]
        public string Label;
    }
}
