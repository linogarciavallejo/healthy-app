using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace healthy_api.Models
{
    public partial class HealthyContext : DbContext
    {
        public HealthyContext()
        {
        }

        public HealthyContext(DbContextOptions<HealthyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<HealthyEvent> HealthyEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeightMonitoring> WeightMonitoring { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=Healthy;Persist Security Info=False;User ID=sa;Password=CanisMajoris19;MultipleActiveResultSets=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.EventTypeId)
                    .HasName("PK__Event_Ty__A9216B3F281D5BD9");

                entity.ToTable("Event_Types");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HealthyEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Healthy___7944C8100BFCCFE7");

                entity.ToTable("Healthy_Events");

                entity.Property(e => e.TimeElapsed).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.WalkingDistance).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.HealthyEvents)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HealthyEvents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserEvents");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4CCAB1C0E2");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WeightMonitoring>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Weight_M__7944C81022281628");

                entity.ToTable("Weight_Monitoring");

                entity.Property(e => e.WeightKgs).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WeightMonitoring)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserWeight");
            });
        }
    }
}
