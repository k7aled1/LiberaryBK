﻿// <auto-generated />
using System;
using LiberaryBK.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiberaryBK.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiberaryBK.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photo");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LiberaryBK.Models.Books", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Book_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookCover")
                        .HasColumnName("Book_Cover");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnName("Book_Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("BookPdf")
                        .IsRequired()
                        .HasColumnName("Book_PDF");

                    b.Property<string>("Description");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int>("TypeF1")
                        .HasColumnName("Type_F1");

                    b.Property<string>("Writer")
                        .IsRequired();

                    b.HasKey("BookId");

                    b.HasIndex("BookId")
                        .IsUnique()
                        .HasName("Name_Books");

                    b.HasIndex("TypeF1")
                        .HasName("IX_Books_Type_Fk_Id");

                    b.HasIndex("Writer");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LiberaryBK.Models.Comments", b =>
                {
                    b.Property<int>("ComntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Comnt_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookF3")
                        .HasColumnName("Book_F3");

                    b.Property<string>("ComntPic")
                        .HasColumnName("Comnt_Pic");

                    b.Property<string>("ComntText")
                        .IsRequired()
                        .HasColumnName("Comnt_Text")
                        .HasMaxLength(250);

                    b.Property<string>("UserF4")
                        .IsRequired()
                        .HasColumnName("User_F4");

                    b.HasKey("ComntId");

                    b.HasIndex("BookF3")
                        .HasName("IX_Comments_Book_Fk1_Id");

                    b.HasIndex("UserF4")
                        .HasName("IX_Comments_User_Fk1_Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("LiberaryBK.Models.Followers", b =>
                {
                    b.Property<int>("FllId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Follower_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FIdU")
                        .IsRequired()
                        .HasColumnName("User");

                    b.Property<string>("FollowU")
                        .IsRequired()
                        .HasColumnName("Followers");

                    b.HasKey("FllId");

                    b.HasIndex("FIdU");

                    b.HasIndex("FollowU", "FIdU")
                        .IsUnique()
                        .HasName("Follower_sss");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("LiberaryBK.Models.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookF2")
                        .HasColumnName("Book_F2");

                    b.Property<int>("Stars");

                    b.Property<string>("UserF3")
                        .IsRequired()
                        .HasColumnName("User_F3");

                    b.HasKey("RateId");

                    b.HasIndex("BookF2");

                    b.HasIndex("UserF3");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("LiberaryBK.Models.ReadBook", b =>
                {
                    b.Property<int>("ReadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Read_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookF1")
                        .HasColumnName("Book_F1");

                    b.Property<string>("UserF2")
                        .IsRequired()
                        .HasColumnName("User_F2");

                    b.HasKey("ReadId");

                    b.HasIndex("BookF1");

                    b.HasIndex("UserF2");

                    b.ToTable("Read_Book");
                });

            modelBuilder.Entity("LiberaryBK.Models.Types", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Type_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnName("Type_Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("TypeId");

                    b.HasIndex("TypeId")
                        .IsUnique()
                        .HasName("Type");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(450);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LiberaryBK.Models.Books", b =>
                {
                    b.HasOne("LiberaryBK.Models.Types", "TypeF1Navigation")
                        .WithMany("Bookss")
                        .HasForeignKey("TypeF1")
                        .HasConstraintName("FK_Books_Types1");

                    b.HasOne("LiberaryBK.Models.AppUser", "Userr")
                        .WithMany("Bookss")
                        .HasForeignKey("Writer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiberaryBK.Models.Comments", b =>
                {
                    b.HasOne("LiberaryBK.Models.Books", "BookF3Navigation")
                        .WithMany("Comments")
                        .HasForeignKey("BookF3")
                        .HasConstraintName("FK_Comments_Books1");

                    b.HasOne("LiberaryBK.Models.AppUser", "Userc")
                        .WithMany("Commentsu")
                        .HasForeignKey("UserF4")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiberaryBK.Models.Followers", b =>
                {
                    b.HasOne("LiberaryBK.Models.AppUser", "FIdUNavigation")
                        .WithMany("FollowerFIdUNavigation")
                        .HasForeignKey("FIdU")
                        .HasConstraintName("FK_Follower_Userss");

                    b.HasOne("LiberaryBK.Models.AppUser", "FollowUNavigation")
                        .WithMany("FollowerFollowUNavigation")
                        .HasForeignKey("FollowU")
                        .HasConstraintName("FK_Follower_Userss1");
                });

            modelBuilder.Entity("LiberaryBK.Models.Rate", b =>
                {
                    b.HasOne("LiberaryBK.Models.Books", "BookF2Navigation")
                        .WithMany("Rate")
                        .HasForeignKey("BookF2")
                        .HasConstraintName("FK_Rate_Books1");

                    b.HasOne("LiberaryBK.Models.AppUser", "UserRate")
                        .WithMany("Ratesu")
                        .HasForeignKey("UserF3")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiberaryBK.Models.ReadBook", b =>
                {
                    b.HasOne("LiberaryBK.Models.Books", "BookF1Navigation")
                        .WithMany("ReadBook")
                        .HasForeignKey("BookF1")
                        .HasConstraintName("FK_Read_Book_Books1");

                    b.HasOne("LiberaryBK.Models.AppUser", "UserRB")
                        .WithMany()
                        .HasForeignKey("UserF2")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LiberaryBK.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LiberaryBK.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LiberaryBK.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LiberaryBK.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
