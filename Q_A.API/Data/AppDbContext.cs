using Microsoft.EntityFrameworkCore;
using Q_A.API.Models;

namespace Q_A.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<question> question { get; set; }
    }
}