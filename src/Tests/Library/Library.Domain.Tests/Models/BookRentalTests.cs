using FluentAssertions;
using Library.Domain.Enums;
using Library.Domain.Events;
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Domain.Tests.Models;

public class BookRentalTests
{
    [Fact]
    public void Criar_DeveRetornarBookRentalQuandoDadosValidosSaoInformados()
    {
        var id = BookRentalId.Of(Guid.NewGuid());
        var bookId = BookId.Of(Guid.Parse("1ca7f182-d63a-4726-844d-02c322d6a7a0"));
        var personId = PersonId.Of(Guid.Parse("e3183407-60ae-42fe-87c0-1ca878e8d6da"));
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 2, 1);
        var status = BookRentStatus.Encerrado;

        var rental = BookRental.Create(id, bookId, personId, startDate, endDate, status);

        rental.Should().NotBeNull();
        rental.Id.Should().Be(id);
        rental.BookId.Should().Be(bookId);
        rental.PersonId.Should().Be(personId);
        rental.StartDate.Should().Be(startDate);
        rental.EndDate.Should().Be(endDate);
        rental.Status.Should().Be(status);
    }

    [Fact]
    public void Criar_DeveCriarBookRentalCreatedEvent_QuandoBookReantalForCriado()
    {
        var id = BookRentalId.Of(Guid.NewGuid());
        var bookId = BookId.Of(Guid.Parse("1ca7f182-d63a-4726-844d-02c322d6a7a0"));
        var personId = PersonId.Of(Guid.Parse("e3183407-60ae-42fe-87c0-1ca878e8d6da"));
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 2, 1);
        var status = BookRentStatus.Encerrado;

        var rental = BookRental.Create(id, bookId, personId, startDate, endDate, status);

        rental.DomainEvents.Should().ContainSingle(e => e is BookRentalCreatedEvent);
    }

    [Fact]
    public void Editar_DeveRealizarAsAlteracoes_QuandoStatusForAlterado()
    {
        var id = BookRentalId.Of(Guid.NewGuid());
        var bookId = BookId.Of(Guid.Parse("1ca7f182-d63a-4726-844d-02c322d6a7a0"));
        var personId = PersonId.Of(Guid.Parse("e3183407-60ae-42fe-87c0-1ca878e8d6da"));
        var startDate = DateTime.UtcNow;
        var endDate = startDate.AddDays(7);
        var status = BookRentStatus.Vigencia;

        var rental = BookRental.Create(id, bookId, personId, startDate, endDate, status);
        var novoStatus = BookRentStatus.Encerrado;

        rental.Update(novoStatus);

        rental.Status.Should().Be(novoStatus);
        rental.DomainEvents.Should().ContainSingle(e => e is BookRentalUpdatedEvent);
    }
}
