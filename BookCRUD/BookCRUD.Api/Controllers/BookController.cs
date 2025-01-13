using BookCRUD.Repository.Services;
using BookCRUD.Service.DTOs;
using BookCRUD.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUD.Api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpPost("addBook")]
        public Guid AddBook(BookDto bookDto)
        {
            return _bookService.AddBook(bookDto);
        }
        [HttpGet("getAllBooks")]
        public List<BookDto> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }
        [HttpPut("updateBook")]
        public void UpdateBook(BookDto bookDto)
        {
            _bookService.UpdateBook(bookDto);
        }
        [HttpDelete("deleteBook")]
        public void DeleteBook(Guid id)
        {
            _bookService.DeleteBook(id);
        }
        [HttpGet("detById")]
        public BookDto GetById(Guid id)
        {
            return _bookService.GetById(id);
        }
        [HttpGet("getAllBooksByAuthor")]
        public List<BookDto> GetAllBooksByAuthor(string author)
        {
            return _bookService.GetAllBooksByAuthor(author);
        }
        [HttpGet("getTopRatedBook")]
        public BookDto GetTopRatedBook()
        {
            return _bookService.GetTopRatedBook();
        }
        [HttpGet("getBooksPublishedAfterYear")]
        public List<BookDto> GetBooksPublishedAfterYear(int year)
        {
            return _bookService.GetBooksPublishedAfterYear(year);
        }
        [HttpGet("getMostPopularBook")]
        public BookDto GetMostPopularBook()
        {
            return _bookService.GetMostPopularBook();
        }
        [HttpGet("searchBooksByTitle")]
        public List<BookDto> SearchBooksByTitle(string keyword)
        {
            return _bookService.SearchBooksByTitle(keyword);
        }
        [HttpGet("getBooksWithinPageRange")]
        public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
        {
            return _bookService.GetBooksWithinPageRange(minPages, maxPages);
        }
        [HttpGet("getTotalCopiesSoldByAuthor")]
        public int GetTotalCopiesSoldByAuthor(string author)
        {
            return _bookService.GetTotalCopiesSoldByAuthor(author);
        }
        [HttpGet("getBooksSortedByRating")]
        public List<BookDto> GetBooksSortedByRating()
        {
            return _bookService.GetBooksSortedByRating();
        }
        [HttpGet("getRecentBooks")]
        public List<BookDto> GetRecentBooks(int years)
        {
            return _bookService.GetRecentBooks(years);
        }
    }
}
