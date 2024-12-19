namespace BooksStore.Api.Dtos;

public record class CreateBookDto(
    string Title,
    string Description,
    decimal Price,
    DateOnly PublishedOn
);
