using FeederDotNet.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeederDotNet.Services
{
    public interface ISeedServices
    {
        List<Dataset> getAllSources();

        Task Execute();
        
    }
}
