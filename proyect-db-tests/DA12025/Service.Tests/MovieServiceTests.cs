using System.Runtime.CompilerServices;
using Domain;
using Services;
using Services.DataAccess;
using Services.Interfaces;
using Services.Models;

namespace Service.Tests;

[TestClass]
public class MovieServiceTests
{
    private AppDbContext _context;
    private readonly IAppContextFactory _contextFactory = new InMemoryAppContextFactory();
    private MovieRepository _movieRepository;
    private MovieService _movieService;
    private Movie movie;
    private MovieDTO movieDto;

    [TestInitialize]
    public void SetUp()
    {
        _context = _contextFactory.CreateDbContext();
        _movieRepository = new MovieRepository(_context);
        _movieService = new MovieService(_movieRepository);
        movie = new Movie(1, "Black Rain", "Ridley Scott", new DateTime(1989, 9, 22), 30000000);
        movieDto = new MovieDTO();
        movieDto.Id = 1;
        movieDto.Title = "Black Rain";
        movieDto.Director = "Ridley Scott";
        movieDto.ReleaseDate = new DateTime(1989, 9, 22);
        movieDto.Budget = 30000000;
    }

    [TestCleanup]
    public void CleanUp()
    {
        _context.Database.EnsureDeleted();
    }

    [TestMethod]
    public void GetAll_WhenGetAllIsInvoked_ThenAllMoviesAreReturned()
    {
        //Arrange
        _movieRepository.Add(movie);
        //Act
        var movies = _movieService.GetMovies();
        //Assert
        Assert.IsTrue(movies.Exists(m => m.Title == "Black Rain"));
        Assert.AreEqual(1, movies.Count);
    }

    [TestMethod]
    public void AddMovie_WhenAddMovieIsInvoked_ThenTheNewMovieIsAdded()
    {
        //Arrange
        //Act
        _movieService.AddMovie(movieDto);
        //Assert
        var addedMovie = _movieRepository.GetAll().FirstOrDefault(m => m.Title == movieDto.Title);
        Assert.IsNotNull(addedMovie);
        Assert.AreEqual(movieDto.Title, addedMovie.Title);
        Assert.AreEqual(movieDto.Director, addedMovie.Director);
        Assert.AreEqual(movieDto.ReleaseDate, addedMovie.ReleaseDate);
        Assert.AreEqual(movieDto.Budget, addedMovie.Budget);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddMovie_WhenAddTheSameMovieTwice_ThenThrowException()
    {
        //Arrange
        //Act
        _movieService.AddMovie(movieDto);
        _movieService.AddMovie(movieDto);
        //assert
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetMovie_WhenGetUndefinedMovie_ThenThrowException()
    {
        //Arrange
        //Act
        _movieService.GetMovie("movie title");
        //Assert
    }

    [TestMethod]
    public void GetMovie_WhenGetAValidMovie_ThenTheMovieIsReturned()
    {
        //Arrange
        _movieRepository.Add(movie);
        //Act
        var result = _movieService.GetMovie(movie.Title);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(movie.Title, result.Title);
        Assert.AreEqual(movie.Director, result.Director);
        Assert.AreEqual(movie.ReleaseDate, result.ReleaseDate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DeleteMovie_WhenDeleteUndefinedMovie_ThenThrowException()
    {
        //Arrange
        //Act
        _movieService.DeleteMovie("movie title");
        //Assert
    }

    [TestMethod]
    public void DeleteMovie_WhenDeleteAValidMovie_ThenTheMovieIsDeletedFromDatabase()
    {
        //Arrange
        _movieRepository.Add(movie);
        //Act
        _movieService.DeleteMovie(movie.Title);
        //Assert
        Assert.AreEqual(0, _movieRepository.GetAll().Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateMovie_WhenUpdateAnInValidMovie_ThenThrowException()
    {
        //Arrange
        //Act
        _movieService.UpdateMovie(movieDto);
        //Assert
    }

    [TestMethod]
    public void UpdateMovie_WhenUpdateAValidMovie_ThenMovieIsUpdated()
    {
        //Arrange
        _movieService.AddMovie(movieDto);
        movieDto.Director = "New Director";
        movieDto.ReleaseDate = new DateTime(2000, 1, 1);
        //Act
        _movieService.UpdateMovie(movieDto);
        //Assert
        var updatedMovie = _movieRepository.GetAll().First();
        Assert.AreEqual("New Director", updatedMovie.Director);
        Assert.AreEqual(new DateTime(2000, 1, 1), updatedMovie.ReleaseDate);
    }
}