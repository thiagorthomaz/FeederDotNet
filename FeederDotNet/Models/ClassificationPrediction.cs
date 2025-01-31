using Microsoft.ML.Data;

namespace FeederDotNet.Models
{
    public class ClassificationPrediction
    {
        
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }

    }
}
