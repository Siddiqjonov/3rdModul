using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCRUD.Service.DTOs;
using MovieCRUD.Service.Services;

namespace MovieCRUD.Server.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        public MovieController()
        {
            _movieService = new MovieService();
        }
        [HttpPost("addMovie")]
        public Guid AddMovie(MovieDto movieDto)
        {
            return _movieService.AddMovie(movieDto);
        }
        [HttpGet("getAllMovies")]
        public List<MovieDto> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }
        [HttpPut("update")]
        public void Update(MovieDto movieDto)
        {
            _movieService.Update(movieDto);
        }
        [HttpDelete("delete")]
        public void Delete(Guid id)
        {
            _movieService.Delete(id);
        }
        [HttpGet("getMovieById")]
        public MovieDto GetMovieById(Guid id)
        {
            return _movieService.GetMovieById(id);
        }
        [HttpGet("getAllMoviesByDirector")]
        public List<MovieDto> GetAllMoviesByDirector(string director)
        {
            return _movieService.GetAllMoviesByDirector(director);
        }
        [HttpGet("getTopRatedMovie")]
        public MovieDto GetTopRatedMovie()
        {
            return _movieService.GetTopRatedMovie();
        }
        [HttpGet("getMoviesReleasedAfterYear")]
        public List<MovieDto> GetMoviesReleasedAfterYear(int year)
        {
            return _movieService.GetMoviesReleasedAfterYear(year);
        }
        [HttpGet("getHighestGrossingMovie")]
        public MovieDto GetHighestGrossingMovie()
        {
            return _movieService.GetHighestGrossingMovie();
        }
        [HttpGet("searchMoviesByTitle")]
        public List<MovieDto> SearchMoviesByTitle(string keyword)
        {
            return _movieService.SearchMoviesByTitle(keyword);
        }
        [HttpGet("getMoviesWithinDurationRange")]
        public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return _movieService.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }
        [HttpGet("getTotalBoxOfficeEarningsByDirector")]
        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return _movieService.GetTotalBoxOfficeEarningsByDirector(director);
        }
        [HttpGet("getMoviesSortedByRating")]
        public List<MovieDto> GetMoviesSortedByRating()
        {
            return _movieService.GetMoviesSortedByRating();
        }
        [HttpGet("getRecentMovies")]
        public List<MovieDto> GetRecentMovies(int years)
        {
            return _movieService.GetRecentMovies(years);
        }

    }
}
