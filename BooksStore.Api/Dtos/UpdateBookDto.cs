namespace BooksStore.Api.Dtos;

public record class UpdateBookDto(
    string Title,
    string Description,
    decimal Price,
    DateOnly PublishedOn
);

