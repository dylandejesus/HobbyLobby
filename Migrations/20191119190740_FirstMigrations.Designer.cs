﻿// <auto-generated />
using System;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeltExam.Migrations
{
    [DbContext(typeof(HomeContext))]
    [Migration("20191119190740_FirstMigrations")]
    partial class FirstMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeltExam.Models.Association", b =>
                {
                    b.Property<int>("AssociationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HobbyId");

                    b.Property<int>("UserID");

                    b.HasKey("AssociationId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserID");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("BeltExam.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("HobbyName")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserID");

                    b.HasKey("HobbyId");

                    b.HasIndex("UserID");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("BeltExam.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam.Models.Association", b =>
                {
                    b.HasOne("BeltExam.Models.Hobby", "Hobbies")
                        .WithMany("Enthusiasts")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeltExam.Models.User", "Fan")
                        .WithMany("NumOfEnthusiasts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeltExam.Models.Hobby", b =>
                {
                    b.HasOne("BeltExam.Models.User")
                        .WithMany("CoolHobbies")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
