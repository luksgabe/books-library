using BooksLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Infra.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(p => p.Id);
                

            builder.Property(p => p.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(p => p.Author)
                .HasColumnName("author")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Category)
                .HasColumnName("category")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Link)
                .HasColumnName("link")
                .HasColumnType("varchar(100)");

            builder.HasOne(b => b.Image)
                .WithOne(i => i.Book)
                .HasForeignKey<BookImage>(i => i.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
