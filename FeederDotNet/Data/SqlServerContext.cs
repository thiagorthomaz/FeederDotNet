using Microsoft.EntityFrameworkCore;

namespace FeederDotNet.Data
{
    public class SqlServerContext : DbContext
    {

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Article>();


        }

    }
}
