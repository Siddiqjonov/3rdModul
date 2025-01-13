using BookCRUD.DataAccess.Entity;

namespace BookCRUD.Repository.Services;

public interface IBookRepository
{
    Guid Add(Book book);
    List<Book> GetAll();
    void Update(Book book);
    void Delete(Guid id);
    Book GetById(Guid id);
}