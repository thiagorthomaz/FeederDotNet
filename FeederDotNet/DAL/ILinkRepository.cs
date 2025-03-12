using FeederDotNet.Data;

namespace FeederDotNet.DAL
{

    public interface ILinkRepository : IRepository<Models.Link>
    {

        Task<Models.Link?> FindLinkAsync(string url);

    }

}
