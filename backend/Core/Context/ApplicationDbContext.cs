using backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace backend.Core.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Company>Companies { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Candidate> Candidates{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Jobs
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Job)
                .HasForeignKey(j => j.CompanyId);
            modelBuilder.Entity<Job>()
                .Property(j => j.Level)
                .HasConversion<string>();
            #endregion

            #region Candidates
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Job)
                .WithMany(c => c.Candidates)
                .HasForeignKey(c => c.JobId);
            #endregion

            #region Company

            modelBuilder.Entity<Company>()
                .Property(c => c.Size)
                .HasConversion<string>(); 
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
