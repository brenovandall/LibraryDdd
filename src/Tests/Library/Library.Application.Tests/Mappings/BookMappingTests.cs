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
                id: BookId.Of(Guid.Parse("b277d384-d2ef-4c75-babb-40580aa032eb")),
                name: "Clean Code",
                publisher: "Prentice Hall",
                publishDate: new DateTime(2008, 8, 1),
                status: BookStatus.Ativo),
            Book.Create(
                id: BookId.Of(Guid.Parse("66e99666-3fd5-4d35-bc6e-9e6fb93ef045")),
                name: "Domain-Driven Design",
                publisher: "Addison-Wesley",
                publishDate: new DateTime(2004, 8, 30),
                status: BookStatus.Ativo)
        };

        var result = books.ToBookDtoList().ToArray();

        Assert.Equal(2, result.Count());

        Assert.Equal(result[0].Id, Guid.Parse("b277d384-d2ef-4c75-babb-40580aa032eb"));
        Assert.Equal("Clean Code", result[0].Name);
        Assert.Equal("Prentice Hall", result[0].Publisher);
        Assert.Equal(new DateTime(2008, 8, 1), result[0].PublishDate);
        Assert.Equal(BookStatus.Ativo, result[0].Status);

        Assert.Equal(result[1].Id, Guid.Parse("66e99666-3fd5-4d35-bc6e-9e6fb93ef045"));
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
