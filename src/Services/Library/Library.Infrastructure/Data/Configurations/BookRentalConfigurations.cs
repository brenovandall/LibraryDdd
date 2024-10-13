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

        builder.Property(x => x.Id)
            .HasConversion(
                bookId => bookId.Value,
                dbId => BookRentalId.Of(dbId));

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(x => x.BookId);

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(x => x.PersonId);

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
