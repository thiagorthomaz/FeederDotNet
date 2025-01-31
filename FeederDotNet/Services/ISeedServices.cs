using Microsoft.AspNetCore.Mvc.Filters;

namespace FeederDotNet.Services
{
    public interface ISeedServices
    {
        Task Execute();
    }
}
