using Microsoft.EntityFrameworkCore;
using Linq_practice_studnet_6.Models;
namespace Linq_practice_studnet_6.DataAccess
{
    public class ResearchSitesDbContext: DbContext
    {
        public ResearchSitesDbContext(DbContextOptions<ResearchSitesDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
