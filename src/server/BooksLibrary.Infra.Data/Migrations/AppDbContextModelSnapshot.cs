﻿// <auto-generated />
using BooksLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksLibrary.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksLibrary.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("author");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("link");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BooksLibrary.Domain.Entities.BookImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("SmallThumbnail")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("smallThumbnail");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("thumbnail");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookImage", (string)null);
                });

            modelBuilder.Entity("BooksLibrary.Domain.Entities.BookImage", b =>
                {
                    b.HasOne("BooksLibrary.Domain.Entities.Book", "Book")
                        .WithOne("Image")
                        .HasForeignKey("BooksLibrary.Domain.Entities.BookImage", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BooksLibrary.Domain.Entities.Book", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
