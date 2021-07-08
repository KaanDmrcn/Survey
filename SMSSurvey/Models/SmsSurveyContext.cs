using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SMSSurvey.Models
{
    public partial class SmsSurveyContext : DbContext
    {
        public SmsSurveyContext()
        {
        }

        public SmsSurveyContext(DbContextOptions<SmsSurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SmsSurvey> SmsSurveys { get; set; }
        public virtual DbSet<SmsSurveyAnswer> SmsSurveyAnswers { get; set; }
        public virtual DbSet<SmsSurveyPerson> SmsSurveyPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-SIEITHL;Database=SmsSurvey;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<SmsSurvey>(entity =>
            {
                entity.ToTable("SmsSurvey");

                entity.Property(e => e.InsertedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SmsSurveyAnswer>(entity =>
            {
                entity.ToTable("SmsSurveyAnswer");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.SmsSurvey)
                    .WithMany(p => p.SmsSurveyAnswers)
                    .HasForeignKey(d => d.SmsSurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SmsSurveyAnswer_SmsSurvey");
            });

            modelBuilder.Entity<SmsSurveyPerson>(entity =>
            {
                entity.ToTable("SmsSurveyPerson");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EmployeeId).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SmsResult).HasMaxLength(50);

                entity.HasOne(d => d.SmsSurvey)
                    .WithMany(p => p.SmsSurveyPeople)
                    .HasForeignKey(d => d.SmsSurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SmsSurveyPerson_SmsSurvey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
