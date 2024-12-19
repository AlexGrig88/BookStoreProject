using BooksStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<BookDto> books = [
    new (
        1,
        "Террор",
        "Лёд и холод сковал всё вокруг. Экспедиция в Северном Ледовитом океане была обречена. Их ждало неведомое чудовище.",
        1800.50M,
        new DateOnly(2012, 1, 1)
    ),
    new (
        2,
        "Преступление и наказание",
        "Раскольников задавался вопросом: Тварь ли я дрожащая или право имею?. И тогда он пошёл на страшное преступление, убийство старушки процентщицы.",
        790.00M,
        new DateOnly(1988, 9, 20)
    ),
    new (
        3,
        "Имя Розы",
        "В небольшой храм едут двое служителей церкви. Там происходят загадочные убийства, которые им предстоит раскрыть.",
        550.80M,
        new DateOnly(1999, 5, 10)
    )
];

const string GetBookEndpointName = "GetBook";

// GET: /books
app.MapGet("books", () => books);


// GET: /books/1
app.MapGet("books/{id}", (int id) => books.Find(book => book.Id == id))
    .WithName(GetBookEndpointName);  

// POST: /books
app.MapPost("books", (CreateBookDto newBook) => {
    BookDto book = new (
        books.Count + 1,
        newBook.Title,
        newBook.Description,
        newBook.Price,
        newBook.PublishedOn
    );
    books.Add(book);
    return Results.CreatedAtRoute(GetBookEndpointName, new { id = book.Id }, book);
});

// PUT: books/1
app.MapPut("books/{id}", (int id, UpdateBookDto updatedBook) => {
    var index = books.FindIndex(book => book.Id == id);
    books[index] = new BookDto(
        id, updatedBook.Title, 
        updatedBook.Description, 
        updatedBook.Price, 
        updatedBook.PublishedOn
    );
    return Results.NoContent();
});

// DELETE: /books/1
app.MapDelete("books/{id}", (int id) => {
    books.RemoveAll(book => book.Id == id);

    return Results.NoContent();
});


app.Run();
