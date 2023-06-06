using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HFC.Domain;
using HFC.Domain.Common;

namespace HFC.Persistence
{
    public class HFCDbContext : IdentityDbContext<AppUser>
    {
        public HFCDbContext(DbContextOptions<HFCDbContext> options)
         : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HFCDbContext).Assembly);

            // Configure one-to-many relationship between Task and CheckList


            // Configure the relationships
            modelBuilder.Entity<Domain.Task>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.CreatorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // the relationship between Staff and Photo
            modelBuilder.Entity<Staff>()
              .HasOne(s => s.Photo)
              .WithOne()
              .HasForeignKey<Staff>(s => s.PhotoId)
              .OnDelete(DeleteBehavior.Cascade);



        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Photo> Photos { get; set; }

    }
}