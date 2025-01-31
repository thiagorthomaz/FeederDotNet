using FeederDotNet.Services;

namespace FeederDotNet.Workers
{
    public class SeederWorker
    {

        private readonly ICrawlerServices crawlerServices;
        private readonly ISeedServices seedServices;

        public SeederWorker(ICrawlerServices _crawlerServices, ISeedServices _seedServices)
        {
            crawlerServices = _crawlerServices;
            seedServices = _seedServices;

        }

        public async Task Execute() {

            await seedServices.Execute();

        }

    }
}
