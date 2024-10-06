using FluentAssertions;
using Library.Domain.Enums;
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Domain.Tests.Models;

public class BookTests
{
    [Fact]
    public void Criar_DeveRetornarBookQuandoDadosValidosSaoInformados()
    {
        var id = BookId.Of(Guid.NewGuid());
        var name = "A culpa é das estrelas";
        var publisher = "Intrínseca";
        var publishDate = new DateTime(2014, 10, 14);
        var status = BookStatus.Ativo;

        var book = Book.Create(id, name, publisher, publishDate, status);

        book.Should().NotBeNull();
        book.Name.Should().Be(name);
        book.Publisher.Should().Be(publisher);
        book.PublishDate.Should().Be(publishDate);
        book.Status.Should().Be(status);
    }

    [Fact]
    public void Criar_DeveRetornarArgumentExceptionQuandoNameForNull()
    {
        var id = BookId.Of(Guid.NewGuid());
        var publisher = "Intrínseca";
        var publishDate = new DateTime(2014, 10, 14);
        var status = BookStatus.Ativo;

        Action act = () => Book.Create(id, null, publisher, publishDate, status);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'name')");
    }

    [Fact]
    public void Criar_DeveRetornarArgumentExceptionQuandoPublisherForNull()
    {
        var id = BookId.Of(Guid.NewGuid());
        var name = "A culpa é das estrelas";
        var publishDate = new DateTime(2014, 10, 14);
        var status = BookStatus.Ativo;

        Action act = () => Book.Create(id, name, null, publishDate, status);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'publisher')");
    }

    [Fact]
    public void Criar_DeveSerAceitoQuandoPublishDateForNull()
    {
        var id = BookId.Of(Guid.NewGuid());
        var name = "A culpa é das estrelas";
        var publisher = "Intrínseca";
        var status = BookStatus.Ativo;

        var book = Book.Create(id, name, publisher, null, status);

        book.PublishDate.Should().BeNull();
    }

    [Fact]
    public void Criar_DeveRetornarArgumentOutOfRangeExceptionQuandoStatusForNull()
    {
        var id = BookId.Of(Guid.NewGuid());
        var name = "A culpa é das estrelas";
        var publisher = "Intrínseca";
        var publishDate = new DateTime(2014, 10, 14);

        Action act = () => Book.Create(id, name, publisher, publishDate, null);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'value')");
    }
}
