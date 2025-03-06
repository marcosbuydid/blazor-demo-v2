namespace Domain;

public class Movie
{
    private string title;
    private string director;
    private DateTime releaseDate;
    private int budget;

    public string Title
    {
        get { return title; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Title cannot be null or empty");
            }

            title = value;
        }
    }

    public string Director
    {
        get { return director; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Director cannot be null or empty");
            }

            director = value;
        }
    }

    public DateTime ReleaseDate
    {
        get { return releaseDate; }
        set { releaseDate = value; }
    }

    public int Budget
    {
        get { return budget; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Budget must be a positive number");
            }

            budget = value;
        }
    }

    public Movie(string title, string director, DateTime releaseDate, int budget)
    {
        Title = title;
        Director = director;
        ReleaseDate = releaseDate;
        Budget = budget;
    }
}