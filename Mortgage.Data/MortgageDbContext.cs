using Microsoft.EntityFrameworkCore;


namespace Mortgage.Data
{
    public class MortgageDbContext : DbContext
    {
        public MortgageDbContext(DbContextOptions<MortgageDbContext> options) : base(options)
        {

        }

        public DbSet<Entity.Mortgage> Mortgages { get; set; }
    }
}
