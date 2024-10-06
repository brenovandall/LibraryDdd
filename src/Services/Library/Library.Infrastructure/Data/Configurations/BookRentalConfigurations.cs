using Library.Domain.Enums;
using Library.Domain.Models;
using Library.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations;

public class BookRentalConfigurations : IEntityTypeConfiguration<BookRental>
{
    public void Configure(EntityTypeBuilder<BookRental> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.BookId)
            .HasConversion(
                bookId => bookId.Value,
                dbId => BookId.Of(dbId));


        builder.HasMany<Book>()
            .WithMany();

        builder.HasMany<Person>()
            .WithMany();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.StartDate);

        builder.Property(x => x.Status)
            .HasDefaultValue(BookRentStatus.Vigencia)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (BookRentStatus)Enum.Parse(typeof(BookRentStatus), dbStatus));
    }
}
