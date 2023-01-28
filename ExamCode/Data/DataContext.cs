using ExamCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamCode.Data
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
