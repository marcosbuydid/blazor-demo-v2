namespace Domain
{
    public class Movie
    {
        private int? id;
        private string title;
        private string director;
        private DateTime releaseDate;
        private int budget;

        public int? Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty");
                }
                title = value;
            }
        }
        public string Director
        {
            get
            {
                return director;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Director cannot be null or empty");
                }
                director = value;
            }

        }
        public DateTime ReleaseDate { get; set; }
        public int Budget
        {
            get
            {
                return budget;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget of the movie must be a positive number");
                }
                budget = value;
            }
        }

        public Movie() { }

        public Movie(int? id, string title, string director, DateTime releaseYear, int budget)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseDate = releaseYear;
            Budget = budget;
        }
    }
}
