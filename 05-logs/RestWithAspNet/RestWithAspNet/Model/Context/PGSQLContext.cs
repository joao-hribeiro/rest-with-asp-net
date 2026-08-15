using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet.Model.Context
{
    public class PGSQLContext : DbContext
    {
        public PGSQLContext(DbContextOptions<PGSQLContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
    }
}
