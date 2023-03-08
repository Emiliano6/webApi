using Microsoft.EntityFrameworkCore;
using webApi.Data;
namespace webApi
{
    public class ApplicationDB: DbContext
    {
        public ApplicationDB(DbContextOptions options): base(options)
        {
        }
        public DbSet<Acuario> Acuarios { get; set; }
        public DbSet<Pecera> Peceras { get; set; }
    }
}
