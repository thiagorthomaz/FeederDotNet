namespace FeederDotNet.Services
{
    public interface IScraperServices
    {
        Task<Models.Article> Execute(string url);
    }
}
