using FeederDotNet.Services;

namespace FeederDotNet.Workers
{
    public class CrawlerWroker
    {

        ICrawlerServices crawlerServices;

        public CrawlerWroker(ICrawlerServices _crawlerServices)
        {
            crawlerServices = _crawlerServices;

        }

        public async Task Execute() {

            await crawlerServices.Execute();


        }

    }
}
