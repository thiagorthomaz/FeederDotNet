using FeederDotNet.Services;

namespace FeederDotNet.Workers
{
    public class MLWorker
    {

        private readonly IPredictionServices predictionServices;

        public MLWorker(IPredictionServices _predictionServices)
        {
            predictionServices = _predictionServices;
        }

        public async Task TrainDataSet()
        {

            await predictionServices.TrainAsync();

            //await crawlerServices.Execute();

        }

    }
}
