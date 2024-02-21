using MicroserviceProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceProduct.DBContexts
{
    public partial class MicroserviceProductContext : DbContext
    {
        public MicroserviceProductContext()
        {
        }

        public MicroserviceProductContext(DbContextOptions<MicroserviceProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accouts { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-U412UET\\DESAROLLO;Initial Catalog=MicroserviceProduct;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("interestRate");

                entity.Property(e => e.NumbeOfPeriods).HasColumnName("numbeOfPeriods");

                entity.Property(e => e.SavedMontlyAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("savedMontlyAmount");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accouts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accouts__userId__398D8EEE");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
