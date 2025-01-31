namespace FeederDotNet.Services
{

    public interface ICrawlerServices
    {
        Task<Models.Article> Execute(string url);
    }
}
