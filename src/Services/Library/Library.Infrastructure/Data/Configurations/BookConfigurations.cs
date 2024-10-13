using Library.Domain.Enums;
using Library.Domain.Models;
using Library.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations;

public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            bookId => bookId.Value,
            dbId => BookId.Of(dbId));

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Publisher)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PublishDate);

        builder.Property(x => x.Status)
            .HasDefaultValue(BookStatus.Ativo)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (BookStatus)Enum.Parse(typeof(BookStatus), dbStatus));
    }
}
