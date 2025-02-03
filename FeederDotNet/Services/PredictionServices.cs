using FeederDotNet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace FeederDotNet.Services
{
    public class PredictionServices : IPredictionServices
    {

        private readonly MLContext mlContext;
        private readonly String modelPath;
        private readonly ISeedServices seedServices;
        private readonly ICrawlerServices crawlerServices;


        public PredictionServices(ISeedServices _seedServices, ICrawlerServices _crawlerServices) {

            mlContext = new MLContext();
            modelPath = "./Data/trained_model.zip";

            seedServices = _seedServices;
            crawlerServices = _crawlerServices;

        }

        public async Task TrainAsync() {

            try {

                DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<ClassificationData>();

                //string connectionString = @"Server=(localdb)\\MSSqlLocalDb;Database=Feeder;Integrated Security=False;TrustServerCertificate=True;MultipleActiveResultSets=True;Persist Security Info=False;";
                string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Feeder;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                string sqlCommand = "SELECT * from Dataset;";

                DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, sqlCommand);

                IDataView dataView = loader.Load(dbSource);


                // Split the data into train and test sets
                var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
                var trainSet = trainTestSplit.TrainSet;
                var testSet = trainTestSplit.TestSet;


                // Data processing pipeline
                var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Text.FeaturizeText(
                  outputColumnName: "Features",
                  inputColumnName: nameof(ClassificationData.ClassificationText)));

                //Training Algorithm

                var trainer = mlContext.MulticlassClassification
                  .Trainers
                  .SdcaMaximumEntropy(
                    labelColumnName: "Label", featureColumnName: "Features");

                var trainingPipeline = dataProcessPipeline
                    .Append(trainer)
                    .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

                //Model Training
                var trainedModel = trainingPipeline.Fit(trainSet);

                //Model Evaluation
                var predictions = trainedModel.Transform(testSet);
                var metrics = mlContext.MulticlassClassification.Evaluate(predictions, "Label");

                //Displaying Evaluation Metrics
                //Console.WriteLine($"Macro accuracy: {metrics.MacroAccuracy:P2}");
                //Console.WriteLine($"Micro accuracy: {metrics.MicroAccuracy:P2}");
                //Console.WriteLine($"Log loss: {metrics.LogLoss:P2}");

                // Save the trained model to a file
                mlContext.Model.Save(trainedModel, dataView.Schema, modelPath);

            }
            catch (Exception e) { 
                Console.WriteLine($"Exception: {e.Message}");
            }
            

        }


        public async Task PredictDataSetTest() {


            // Load the trained model
            var loadedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);

            // Create prediction engine
            var predEngine = mlContext.Model.CreatePredictionEngine<ClassificationData, ClassificationPrediction>(loadedModel);

            List<Dataset> sources = seedServices.getAllSources();

            foreach (Dataset src in sources) {

                Article Article = await crawlerServices.Execute(src.Url);

                // Sample text for prediction
                var sampleText = new ClassificationData
                {
                    ClassificationText = Article.TextContent
                };

                // Make a prediction
                var predictionResult = predEngine.Predict(sampleText);

                // Display the prediction
                if (src.Classification == predictionResult.Prediction)
                {
                    Console.WriteLine($"Correct prediction: {predictionResult.Prediction}");
                }
                else {
                    Console.WriteLine($"Wrong prediction: {predictionResult.Prediction}");
                }
                

            }

        }



    }
}
