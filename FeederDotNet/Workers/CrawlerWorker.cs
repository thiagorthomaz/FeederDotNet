using FeederDotNet.Services;

namespace FeederDotNet.Workers
{
    public class CrawlerWorker
    {

        ICrawlerServices crawlerServices;

        public CrawlerWorker(ICrawlerServices _crawlerServices)
        {
            crawlerServices = _crawlerServices;

        }

        public async Task Execute() {

            //await crawlerServices.Execute();

        }

    }
}
