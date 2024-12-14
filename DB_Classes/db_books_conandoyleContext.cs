using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SUBD_books_project.DB_Classes
{
    public partial class db_books_conandoyleContext : DbContext
    {
        public db_books_conandoyleContext()
        {
        }

        public db_books_conandoyleContext(DbContextOptions<db_books_conandoyleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<PublishingHouses> PublishingHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseSqlServer("Data Source=DESKTOP-IDEQ7ON;Initial Catalog=db_books_conandoyle;Integrated Security=True;TrustServerCertificate=True")
                    .UseLazyLoadingProxies(); // Добавляем поддержку ленивой загрузки
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPublishingHouse).HasColumnName("id_publishing_house");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPublishingHouseNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdPublishingHouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__books__id_publis__46E78A0C");
            });

            modelBuilder.Entity<PublishingHouses>(entity =>
            {
                entity.ToTable("publishing_houses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
