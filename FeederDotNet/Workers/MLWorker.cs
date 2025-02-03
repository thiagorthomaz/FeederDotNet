using FeederDotNet.Services;

namespace FeederDotNet.Workers
{
    public class MLWorker
    {

        private readonly IPredictionServices predictionServices;
        private readonly ISeedServices seedServices;

        public MLWorker(IPredictionServices _predictionServices, ISeedServices _seedServices)
        {
            predictionServices = _predictionServices;
            seedServices = _seedServices;
        }

        public async Task TrainDataSet()
        {

            await predictionServices.TrainAsync();

            //await crawlerServices.Execute();

        }

        public async Task PredictDataSetTest()
        {
            await predictionServices.PredictDataSetTest();

            //await crawlerServices.Execute();

        }

    }
}
