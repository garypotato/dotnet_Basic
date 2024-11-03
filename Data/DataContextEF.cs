using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data 
{
    public class DataContextEF : DbContext
    {
        private string _connectionString;

        public DataContextEF(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") 
                                ?? throw new ArgumentNullException(nameof(config), "Connection string 'DefaultConnection' not found.");
        }
        
        public DbSet<Computer>? Computer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer(_connectionString,
                options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>().ToTable("Computer", "TutorialAppSchema")
                .HasKey(c => c.ComputerId);
        }
    }
}