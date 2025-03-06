using Domain;

namespace Services.DataAccess;

public class DBInMemory
{
    public List<Movie> Movies { get; set; }

    public DBInMemory()
    {
        Movies = new List<Movie>();
    }
}