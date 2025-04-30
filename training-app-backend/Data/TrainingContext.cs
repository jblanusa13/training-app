using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TrainingApp.Model;

namespace TrainingApp.Data
{
    public class TrainingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
