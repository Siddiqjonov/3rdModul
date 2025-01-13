using BookCRUD.DataAccess.Entity;
using BookCRUD.Repository.Services;
using BookCRUD.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCRUD.Service.Service;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    public BookService()
    {
        _bookRepository = new BookRepository();
    }
    public Guid AddBook(BookDto bookDto)
    {
        return _bookRepository.Add(ConvertToBookEntity(bookDto));
    }

    public void DeleteBook(Guid id)
    {
        _bookRepository.Delete(id);
    }

    public List<BookDto> GetAllBooks()
    {
        return _bookRepository.GetAll().Select(book => ConvertToBookDto(book)).ToList();
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        return GetAllBooks().Where(book => book.Author.ToLower().Equals(author.ToLower())).ToList();
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        return GetAllBooks().Where(book => book.PublishedDate.Year.Equals(year)).ToList();
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return GetAllBooks().OrderByDescending(book => book.Rating).ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        return GetAllBooks().Where(book => book.Pages >= minPages && book.Pages <= maxPages).ToList();
    }

    public BookDto GetById(Guid id)
    {
        var book = _bookRepository.GetById(id);
        return ConvertToBookDto(book);
    }

    public BookDto GetMostPopularBook()
    {
        return GetAllBooks().OrderByDescending(book => book.NumberOfCopiesSold).First();
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        return GetAllBooks().Where(book => book.PublishedDate.Year >= years).ToList();
    }

    public BookDto GetTopRatedBook()
    {
        return GetAllBooks().OrderByDescending(book => book.Rating).First();
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        return GetAllBooks().Where(book => book.Author.ToLower().Equals(author.ToLower())).Sum(bk => bk.NumberOfCopiesSold);
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        return GetAllBooks().Where(book => book.Title.ToLower().Contains(keyword.ToLower())).ToList();
    }   

    public void UpdateBook(BookDto bookDto)
    {
        _bookRepository.Update(ConvertToBookEntity(bookDto));
    }

    private Book ConvertToBookEntity(BookDto bookDto)
    {
        return new Book()
        {
            Id = bookDto.Id ?? Guid.NewGuid(),
            Author = bookDto.Author,
            NumberOfCopiesSold = bookDto.NumberOfCopiesSold,
            Pages = bookDto.Pages,
            PublishedDate = bookDto.PublishedDate,
            Rating = bookDto.Rating,
            Title = bookDto.Title,
        };
    }
    private BookDto ConvertToBookDto(Book book)
    {
        return new BookDto()
        {
            Id = book.Id,
            Author = book.Author,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            Pages = book.Pages,
            PublishedDate = book.PublishedDate,
            Rating = book.Rating,
            Title = book.Title,
        };
    }
}
