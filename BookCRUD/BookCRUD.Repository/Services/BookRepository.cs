using BookCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookCRUD.Repository.Services;

public class BookRepository : IBookRepository
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly List<Book> _books;
    public BookRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Books.json");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Books.json");

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
        _books = GetAll();
    }
    public Guid Add(Book book)
    {
        _books.Add(book);
        SavaData();
        return book.Id;
    }

    public void Delete(Guid id)
    {
        var book = GetById(id);
        _books.Remove(book);
        SavaData();
    }

    public List<Book> GetAll()
    {
        var booksJson = File.ReadAllText(_filePath);
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson);
        return books ?? throw new NullReferenceException();
    }

    public Book GetById(Guid id)
    {
        //var bookFromDb = GetAll().FirstOrDefault(bk => bk.Id.Equals(id));
        //return bookFromDb ?? throw new NullReferenceException();
        var book = _books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            throw new Exception($"Music with id {id} not found");
        }

        return book;
    }

    public void Update(Book book)
    {
        var bookFromDb = GetById(book.Id);
        var index = _books.IndexOf(bookFromDb);
        _books[index] = book;
        SavaData();

    }
    private void SavaData()
    {
        var booksJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_filePath, booksJson);
    }
}
