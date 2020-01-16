using Microsoft.EntityFrameworkCore;
namespace BeltExam.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get; set;}
        public DbSet<Hobby> Hobbies {get;set;}
        public DbSet <Association> Associations {get;set;}
    }
}