using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Services;

public interface IMovieService
{
    Guid AddMovie(MovieDto movieDto);
    List<MovieDto> GetAllMovies();
    void Update(MovieDto movieDto);
    void Delete(Guid id);
    MovieDto GetMovieById(Guid id);
    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie(); // ratingi eng baland film qaytarilsin
    List<MovieDto> GetMoviesReleasedAfterYear(int year); // yilidan keyin chiqqan filmlar qaytarilsin
    MovieDto GetHighestGrossingMovie(); // eng ko'p daromad qilgan film qaytarilsin
    List<MovieDto> SearchMoviesByTitle(string keyword); // titleda keyword qatnashgan filmlar royxati qaytsin
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes); // davomiyligi min va max oralig'ida bo'lgan filmlar
    long GetTotalBoxOfficeEarningsByDirector(string director); // directorning filmlari qancha daromad qilgani qaytarilsin
    List<MovieDto> GetMoviesSortedByRating(); // baholanish bo'yicha sortlab bering. Kattadan kichikga
    List<MovieDto> GetRecentMovies(int years); // so'nggi yil ichida chiqqan filmlar royxati qaytarilsin.

}