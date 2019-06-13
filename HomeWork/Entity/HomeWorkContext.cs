using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeWork.Entity
{
    public partial class HomeWorkContext : DbContext {
        public HomeWorkContext() {
        }

        public HomeWorkContext(DbContextOptions<HomeWorkContext> options)
                : base(options) {
        }

        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Realtor> Realtor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HomeWork;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Division>(entity => {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Realtor>(entity => {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

        }

    }
}

    