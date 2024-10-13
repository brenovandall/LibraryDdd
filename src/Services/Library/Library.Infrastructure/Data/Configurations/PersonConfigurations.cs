using Library.Domain.Models;
using Library.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations;

public class PersonConfigurations : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            personId => personId.Value,
            dbId => PersonId.Of(dbId));

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasMaxLength(11)
            .IsRequired();

        builder.HasIndex(x => x.Cpf).IsUnique();

        builder.Property(x => x.BirthDate);
    }
}
