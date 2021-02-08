using System;
using System.Collections.Generic;
using System.Text;
using LiberaryBK.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiberaryBK.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<ReadBook> ReadBook { get; set; }
        public virtual DbSet<Types> Types { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Followers>(entity =>
            {
                entity.HasKey(e => e.FllId);

                entity.HasIndex(e => new { e.FollowU, e.FIdU })
                    .HasName("Follower_sss")
                    .IsUnique();

                entity.Property(e => e.FllId).HasColumnName("Follower_ID");

                entity.Property(e => e.FIdU).HasColumnName("User");

                entity.Property(e => e.FollowU).HasColumnName("Followers");

                entity.HasOne(d => d.FIdUNavigation)
                    .WithMany(p => p.FollowerFIdUNavigation)
                    .HasForeignKey(d => d.FIdU)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follower_Userss");

                entity.HasOne(d => d.FollowUNavigation)
                    .WithMany(p => p.FollowerFollowUNavigation)
                    .HasForeignKey(d => d.FollowU)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follower_Userss1");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.BookId)
                    .HasName("Name_Books")
                    .IsUnique();

                entity.HasIndex(e => e.TypeF1)
                    .HasName("IX_Books_Type_Fk_Id");


                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.BookCover).HasColumnName("Book_Cover");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasColumnName("Book_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookPdf).HasColumnName("Book_PDF");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TypeF1).HasColumnName("Type_F1");


                entity.HasOne(d => d.TypeF1Navigation)
                    .WithMany(p => p.Bookss)
                    .HasForeignKey(d => d.TypeF1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Types1");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.ComntId);

                entity.HasIndex(e => e.BookF3)
                    .HasName("IX_Comments_Book_Fk1_Id");

                entity.HasIndex(e => e.UserF4)
                    .HasName("IX_Comments_User_Fk1_Id");

                entity.Property(e => e.ComntId).HasColumnName("Comnt_Id");

                entity.Property(e => e.BookF3).HasColumnName("Book_F3");

                entity.Property(e => e.ComntPic).HasColumnName("Comnt_Pic");

                entity.Property(e => e.ComntText)
                    .IsRequired()
                    .HasColumnName("Comnt_Text")
                    .HasMaxLength(250);

                entity.Property(e => e.UserF4)
                    .IsRequired()
                    .HasColumnName("User_F4");

                entity.HasOne(d => d.BookF3Navigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BookF3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Books1");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasIndex(e => e.BookF2);

                entity.HasIndex(e => e.UserF3);

                entity.Property(e => e.BookF2).HasColumnName("Book_F2");

                entity.Property(e => e.UserF3)
                    .IsRequired()
                    .HasColumnName("User_F3");

                entity.HasOne(d => d.BookF2Navigation)
                    .WithMany(p => p.Rate)
                    .HasForeignKey(d => d.BookF2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Books1");
            });

            modelBuilder.Entity<ReadBook>(entity =>
            {
                entity.HasKey(e => e.ReadId);

                entity.ToTable("Read_Book");

                entity.HasIndex(e => e.BookF1);

                entity.HasIndex(e => e.UserF2);

                entity.Property(e => e.ReadId).HasColumnName("Read_Id");

                entity.Property(e => e.BookF1).HasColumnName("Book_F1");

                entity.Property(e => e.UserF2)
                    .IsRequired()
                    .HasColumnName("User_F2");

                entity.HasOne(d => d.BookF1Navigation)
                    .WithMany(p => p.ReadBook)
                    .HasForeignKey(d => d.BookF1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Read_Book_Books1");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.HasIndex(e => e.TypeId)
                    .HasName("Type")
                    .IsUnique();

                entity.Property(e => e.TypeId).HasColumnName("Type_Id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("Type_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}