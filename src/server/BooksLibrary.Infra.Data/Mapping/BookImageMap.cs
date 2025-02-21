using BooksLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Infra.Data.Mapping
{
    public class BookImageMap : IEntityTypeConfiguration<BookImage>
    {
        public void Configure(EntityTypeBuilder<BookImage> builder)
        {
            builder.ToTable("BookImage");

            builder.HasKey(p => p.Id);
                

            builder.Property(p => p.Thumbnail)
                .HasColumnName("thumbnail")
                .HasColumnType("varchar(250)");

            builder.Property(p => p.SmallThumbnail)
                .HasColumnName("smallThumbnail")
                .HasColumnType("varchar(250)");

            builder.HasOne(i => i.Book)
                .WithOne(b => b.Image)
                .HasForeignKey<BookImage>(i => i.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
