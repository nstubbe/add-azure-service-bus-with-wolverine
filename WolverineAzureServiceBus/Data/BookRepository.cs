namespace WolverineAzureServiceBus.Data;

public interface IBookRepository
{
    Book? GetById(int id);
    int Create(string title, string author);
}

public class BookRepository : IBookRepository
{
    public List<Book> Books { get; set; } = new List<Book>();
    
    public BookRepository()
    {
        Books.Add(new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien" });
        Books.Add(new Book { Id = 2, Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien" });
        Books.Add(new Book { Id = 3, Title = "The Two Towers", Author = "J.R.R. Tolkien" });
        Books.Add(new Book { Id = 4, Title = "The Return of the King", Author = "J.R.R. Tolkien" });
    }
    
    public Book? GetById(int id)
    {
        return Books.SingleOrDefault(x => x.Id == id);;
    }
    
    public int Create(string title, string author)
    {
        var book = new Book { Id = Books.Max(x => x.Id) + 1, Title = title, Author = author };
        Books.Add(book);
        return book.Id;
    }
}