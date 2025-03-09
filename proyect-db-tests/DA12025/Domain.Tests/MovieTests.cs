namespace Domain.Tests;

[TestClass]
public class MovieTests
{
    [TestMethod]
    public void Movie_EmptyConstructor_ShouldInitializePropertiesToDefaults()
    {
        // Arrange
        Movie movie = new Movie();

        // Assert
        Assert.IsNotNull(movie); 
        Assert.AreEqual(null, movie.Title);
        Assert.AreEqual(null, movie.Director);
        Assert.AreEqual(0, movie.Budget);
    }
    
    [TestMethod]
    public void CreateNewMovie_WhenIdIsNull_ThenMovieIsValid()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(null, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
        Assert.IsNull(movie.Id);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateNewMovie_WhenTitleIsNull_ThenThrowException()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, null, "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
    }

    [TestMethod]
    public void CreateNewMovie_WhenTitleIsNotNullOrEmpty_ThenTitleIsValid()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
        Assert.AreEqual("Gladiator 2", movie.Title);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateNewMovie_WhenDirectorIsNullOrEmpty_ThenThrowException()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "", new DateTime(2024, 11, 22), 250000000);
        //assert
    }

    [TestMethod]
    public void CreateNewMovie_WhenDirectorIsNotNullOrEmpty_ThenDirectorIsValid()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
        Assert.AreEqual("Ridley Scott", movie.Director);
    }

    [TestMethod]
    public void CreateNewMovie_WhenReleaseDateIsEarlierThanToday_ThenReleaseDateIsValid()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
        Assert.AreEqual(new DateTime(2024, 11, 22), movie.ReleaseDate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateNewMovie_WhenBudgetIsNegative_ThenThrowException()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), -250000000);
        //assert
    }

    [TestMethod]
    public void CreateNewMovie_WhenBudgetIsPositive_ThenBudgetIsValid()
    {
        //arrange
        Movie movie;
        //act
        movie = new Movie(1, "Gladiator 2", "Ridley Scott", new DateTime(2024, 11, 22), 250000000);
        //assert
        Assert.AreEqual(250000000, movie.Budget);
    }
}