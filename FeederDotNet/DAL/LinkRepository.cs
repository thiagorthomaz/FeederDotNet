using FeederDotNet.Data;
using FeederDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FeederDotNet.DAL
{
    public class LinkRepository : Repository<Models.Link>, ILinkRepository
    {

        public LinkRepository(SqlServerContext dbContext) : base(dbContext)
        {

        }

        public async Task<Models.Link?> FindLinkAsync(string url)
        {
            Link? link = await GetAll().Where(x => x.Url.ToLower() == url.ToLower()).FirstOrDefaultAsync();
            return link;
        }

    }
}
