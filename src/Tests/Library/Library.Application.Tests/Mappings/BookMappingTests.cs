using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Application.Tests.Mappings;

public class BookMappingTests
{
    [Fact]
    public void ToBookListDto_DeveConverterUmaListaDeBooksParaDtoCorretamente()
    {
        var books = new List<Book>
        {
            Book.Create(
                id: BookId.Of(Guid.NewGuid()),
                name: "Clean Code",
                publisher: "Prentice Hall",
                publishDate: new DateTime(2008, 8, 1),
                status: BookStatus.Ativo),
            Book.Create(
                id: BookId.Of(Guid.NewGuid()),
                name: "Domain-Driven Design",
                publisher: "Addison-Wesley",
                publishDate: new DateTime(2004, 8, 30),
                status: BookStatus.Ativo)
        };

        var result = books.ToBookDtoList().ToArray();

        Assert.Equal(2, result.Count());

        Assert.NotNull(result[0].Id);
        Assert.Equal("Clean Code", result[0].Name);
        Assert.Equal("Prentice Hall", result[0].Publisher);
        Assert.Equal(new DateTime(2008, 8, 1), result[0].PublishDate);
        Assert.Equal(BookStatus.Ativo, result[0].Status);

        Assert.NotNull(result[1].Id);
        Assert.Equal("Domain-Driven Design", result[1].Name);
        Assert.Equal("Addison-Wesley", result[1].Publisher);
        Assert.Equal(new DateTime(2004, 8, 30), result[1].PublishDate);
        Assert.Equal(BookStatus.Ativo, result[1].Status);
    }

    [Fact]
    public void ToBookListDto_DeveRetornarUmaListaVaziaQuandoAListaDeEntityForVazia()
    {
        var books = new List<Book>();

        var result = books.ToBookDtoList().ToList();

        Assert.Empty(result);
    }
}
