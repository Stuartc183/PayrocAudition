using Microsoft.EntityFrameworkCore;
using ShortUrlApi.Data.Entities;

namespace ShortUrlApi.Data.Contexts
{
    public class ShortUrlDbContext : DbContext
    {
        public DbSet<ShortUrlRecordEntity> ShortUrlRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLOCALDB; Initial Catalog=ShortUrlDb");
        }
    }
}
