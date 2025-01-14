using MovieCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieCRUD.Repository.Services;

public class MovieRepository : IMovieRepository
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly List<Movie> _movies;
    public MovieRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Movie.json");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
        _movies = GetAll();
    }
    public Guid Add(Movie movie)
    {
        _movies.Add(movie);
        SavaData();
        return movie.Id;
    }

    public void Delete(Guid id)
    {
        var movie = GetById(id);
        _movies.Remove(movie);
        SavaData();
    }

    public List<Movie> GetAll()
    {
        var moviesJson = File.ReadAllText(_filePath);
        var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);
        return movies ?? throw new NullReferenceException();
    }

    public Movie GetById(Guid id)
    {
        return _movies.FirstOrDefault(x => x.Id == id) ?? throw new NullReferenceException();
        //return GetAll().FirstOrDefault(mv => mv.Id == id) ?? throw new NullReferenceException();
    }

    public void Update(Movie movie)
    {
        var movieFromDb = GetById(movie.Id);
        var index = _movies.IndexOf(movieFromDb);
        _movies[index] = movie;
        SavaData();
    }
    private void SavaData()
    {
        var moviesJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_filePath, moviesJson);
    }
}
