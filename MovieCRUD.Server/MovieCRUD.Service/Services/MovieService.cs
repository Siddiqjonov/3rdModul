using MovieCRUD.DataAccess.Entity;
using MovieCRUD.Repository.Services;
using MovieCRUD.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRUD.Service.Services;

public class MovieService : IMovieService
{
    private IMovieRepository _movieRepository;
    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }
    public Guid AddMovie(MovieDto movieDto)
    {
        return _movieRepository.Add(ConvertToEntity(movieDto));
    }

    public void Delete(Guid id)
    {
        _movieRepository.Delete(id);
    }

    public List<MovieDto> GetAllMovies()
    {
        return _movieRepository.GetAll().Select(mve => ConvertToDto(mve)).ToList();
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAllMovies().Where(mve => mve.Director.ToLower().Equals(director.ToLower())).ToList();
    }

    public MovieDto GetHighestGrossingMovie()
    {
        return GetAllMovies().OrderByDescending(mve => mve.BoxOfficeEarnings).First();
    }

    public MovieDto GetMovieById(Guid id)
    {
        return ConvertToDto(_movieRepository.GetById(id));
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return GetAllMovies().Where(mve => mve.ReleaseDate.Year >= year).ToList();
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return GetAllMovies().OrderByDescending(mve => mve.Rating).ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return GetAllMovies().Where(mve => mve.DurationMinutes >= minMinutes && mve.DurationMinutes <= maxMinutes).ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return GetAllMovies().Where(mve => mve.ReleaseDate.Year >= years).ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        return GetAllMovies().OrderByDescending(mve => mve.Rating).First();
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return GetAllMovies().Where(mve => mve.Director.ToLower().Equals(director.ToLower())).Sum(mv => mv.BoxOfficeEarnings);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return GetAllMovies().Where(mve => mve.Title.ToLower().Contains(keyword.ToLower())).ToList();
    }

    public void Update(MovieDto movieDto)
    {
        _movieRepository.Update(ConvertToEntity(movieDto));
    }

    private static Movie ConvertToEntity(MovieDto movieDto)
    {
        return new Movie()
        {
            Id = movieDto.Id ?? Guid.NewGuid(),
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            ReleaseDate = movieDto.ReleaseDate,
            Title = movieDto.Title,
        };
    }
    private static MovieDto ConvertToDto(Movie movie)
    {
        return new MovieDto()
        {
            Id = movie.Id,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            ReleaseDate = movie.ReleaseDate,
            Title = movie.Title,
        };
    }
}
