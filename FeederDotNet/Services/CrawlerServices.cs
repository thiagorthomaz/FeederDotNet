using AutoMapper;
using FeederDotNet.DAL;
using Hangfire.Server;

namespace FeederDotNet.Services
{
    public class CrawlerServices : ICrawlerServices
    {

        private readonly IArticleRepository articleRepository;

        public CrawlerServices(IArticleRepository _articleRepository)
        {
            articleRepository = _articleRepository;
        }

        public async Task Execute()
        {

            SmartReader.Reader sr = new SmartReader.Reader("https://arstechnica.com/information-technology/2017/02/humans-must-become-cyborgs-to-survive-says-elon-musk/");
            SmartReader.Article article = sr.GetArticle();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SmartReader.Article, Models.Article>());

            var mapper = new Mapper(config);
            Models.Article localArticle = mapper.Map<Models.Article>(article);
            
            await articleRepository.AddAsync(localArticle);

        }

    }
}
