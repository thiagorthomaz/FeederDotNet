using FeederDotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace FeederDotNet.DAL
{
    public class ArticleRepository : Repository<Models.Article>, IArticleRepository
    {
        public ArticleRepository(SqlServerContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Models.Article>> getAllAsync(string userId)
        {

            return GetAll().ToListAsync();

        }
    }
}
