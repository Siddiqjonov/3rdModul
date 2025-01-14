using MovieCRUD.DataAccess.Entity;

namespace MovieCRUD.Repository.Services;

public interface IMovieRepository
{
    Guid Add(Movie movie);
    List<Movie> GetAll();
    void Update(Movie movie);
    void Delete(Guid id);
    Movie GetById(Guid id);
}