using Microsoft.ML.Data;

namespace FeederDotNet.Models
{
    public class ClassificationData
    {
        [LoadColumn(0)]
        public string ClassificationText;

        [LoadColumn(1), ColumnName("Label")]
        public string Classification;
    }
}
