using AutoMapper;
using FeederDotNet.DAL;

namespace FeederDotNet.Services
{
    public class ScraperServices : IScraperServices
    {

        private readonly IArticleRepository articleRepository;

        public ScraperServices(IArticleRepository _articleRepository)
        {
            articleRepository = _articleRepository;
        }

        public async Task test()
        {

            Models.Article article = await Execute("https://arstechnica.com/information-technology/2017/02/humans-must-become-cyborgs-to-survive-says-elon-musk/");
            await articleRepository.AddAsync(article);

        }


        public async Task<Models.Article> Execute(string url)
        {

            SmartReader.Reader sr = new SmartReader.Reader(url);
            SmartReader.Article article = await sr.GetArticleAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SmartReader.Article, Models.Article>());

            var mapper = new Mapper(config);
            Models.Article localArticle = mapper.Map<Models.Article>(article);

            return localArticle;

        }


    }
}
