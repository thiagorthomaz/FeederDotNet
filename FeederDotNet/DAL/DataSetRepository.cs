using FeederDotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace FeederDotNet.DAL
{
    public class DataSetRepository : Repository<Models.Dataset>, IDataSetRepository
    {
        public DataSetRepository(SqlServerContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Models.Dataset>> getAllAsync(string guid)
        {

            return GetAll().ToListAsync();

        }
    }
}
