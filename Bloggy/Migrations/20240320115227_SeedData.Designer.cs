﻿// <auto-generated />
using System;
using Bloggy.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bloggy.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240320115227_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bloggy.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                            CreatedDate = new DateTime(2024, 3, 20, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1426),
                            ImageUrl = "/images/seed1.jpg",
                            Title = "AGA Today"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "Today's traffic can't be described using words. Only an image can do that ...",
                            CreatedDate = new DateTime(2024, 3, 19, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1428),
                            ImageUrl = "/images/seed2.jpg",
                            Title = "Traffic is incredible"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Content = "Clouds clouds all around us. I thought spring started already, but ...",
                            CreatedDate = new DateTime(2024, 3, 18, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1432),
                            ImageUrl = "/images/seed3.jpg",
                            Title = "When is Spring really starting?"
                        });
                });

            modelBuilder.Entity("Bloggy.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Uncategorised"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "News"
                        });
                });

            modelBuilder.Entity("Bloggy.Models.BlogPost", b =>
                {
                    b.HasOne("Bloggy.Models.Category", "Category")
                        .WithMany("BlogPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bloggy.Models.Category", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
