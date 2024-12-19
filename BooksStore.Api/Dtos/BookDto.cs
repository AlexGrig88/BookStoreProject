namespace BooksStore.Api.Dtos;

public record class BookDto(
    int Id,
    string Title,
    string Description,
    decimal Price,
    DateOnly PublishedOn
);