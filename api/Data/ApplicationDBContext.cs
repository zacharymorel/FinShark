using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        // dbContextOptions is defined on Program.cs =>  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}