using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TrainingApp.Core.Model;

namespace TrainingApp.Data
{
    public class TrainingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
