using Microsoft.EntityFrameworkCore;
using MortageApp.Web.Models;

namespace MortageApp.Web.Data
{
    public class MortgageDbContext : DbContext
    {
        public MortgageDbContext(DbContextOptions<MortgageDbContext> options) : base(options)
        {

        }

        public DbSet<Mortgage> Mortgages { get; set; }
    }
}
