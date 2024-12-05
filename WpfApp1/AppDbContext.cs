using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WpfApp1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }  
    }
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public bool IsAnswered { get; set; }
    }

}
