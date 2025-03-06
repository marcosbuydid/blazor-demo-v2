using Domain;
using Services;
using Services.DataAccess;

namespace Service.Tests;

[TestClass]
public class MovieServiceTests
{
    private DBInMemory _dbInMemory;
    private MovieService _movieService;

    [TestInitialize]
    public void Setup()
    {
        _dbInMemory = new DBInMemory();
        _movieService = new MovieService(_dbInMemory);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddNewMovie_WhenAddADuplicateMovie_ThenThrowException()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        //act
        _movieService.AddMovie(movie);
        _movieService.AddMovie(movie);
        //assert
    }

    [TestMethod]
    public void AddNewMovie_WhenAddMovie_ThenReturnSuccessfully()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        //act
        _movieService.AddMovie(movie);
        var retrievedMovie = _dbInMemory.Movies.Find(m => m.Title == movie.Title);
        //assert
        Assert.IsNotNull(retrievedMovie);
        Assert.IsTrue(_dbInMemory.Movies.Count == 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetMovie_WhenGetAnUndefinedMovie_ThenThrowException()
    {
        //arrange
        Movie movie;
        //act
        _movieService.GetMovie("Sing Sing");
        //assert
    }

    [TestMethod]
    public void GetMovie_WhenGetAnExistentMovie_ThenReturnSuccessfully()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        _dbInMemory.Movies.Add(movie);
        //act
        var retrievedMovie = _movieService.GetMovie(movie.Title);
        //assert
        Assert.AreSame(retrievedMovie, movie);
    }

    [TestMethod]
    public void GetMovies_WhenGettingAllMoviesAndThereIsNoMovies_ThenReturnZero()
    {
        //arrange
        //act
        _movieService.GetMovies();
        //assert
        Assert.IsTrue(_dbInMemory.Movies.Count == 0);
    }

    [TestMethod]
    public void GetMovies_WhenGettingAllMovies_ThenReturnAllMovies()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        _dbInMemory.Movies.Add(movie);
        //act
        _movieService.GetMovies();
        //assert
        Assert.IsTrue(_dbInMemory.Movies.Contains(movie));
        Assert.IsTrue(_dbInMemory.Movies.Count == 1);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DeleteMovie_WhenDeleteAnUndefinedMovie_ThenThrowException()
    {
        //arrange
        //act
        _movieService.DeleteMovie("Sing Sing");
        //assert
    }
    
    [TestMethod]
    public void DeleteMovie_WhenDeleteAMovie_ThenReturnSuccessfully()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        _dbInMemory.Movies.Add(movie);
        //act
        _movieService.DeleteMovie(movie.Title);
        //assert
        Assert.IsTrue(_dbInMemory.Movies.Count == 0);
    }
    
    [TestMethod]
    public void UpdateMovie_WhenUpdateAMovie_ThenReturnSuccessfully()
    {
        //arrange
        Movie movie;
        movie = new Movie("Sing Sing", "Greg Kwedar", new DateTime(2024, 07, 12), 2000000);
        _dbInMemory.Movies.Add(movie);
        movie.Budget = 1000000;
        //act
        _movieService.UpdateMovie(movie);
        var retrievedMovie = _dbInMemory.Movies.Find(m => m.Title == movie.Title);
        //assert
        Assert.AreSame(retrievedMovie, movie);
        Assert.AreEqual(1000000, movie.Budget);
    }
}