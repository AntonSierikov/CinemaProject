using MovieDomain.Abstract;
using MovieDomain.Identifiers;

namespace MovieDomain.Entities
{
    public class MovieCompany : DbObject<MovieCompanyId>
    {

        public Movie Movie { get; set; }

        public ProductionCompany Company { get; set; }

        //----------------------------------------------------------------//

        public MovieCompany() {}

        //----------------------------------------------------------------//

        public MovieCompany(int movieId, int companyId)
        {
            Id = new MovieCompanyId(movieId, companyId);
        }

        //----------------------------------------------------------------//

        public MovieCompany(Movie movie, ProductionCompany company)
            : this(movie.Id, company.Id)
        {
            Movie = movie;
            Company = company;
        }

        //----------------------------------------------------------------//

    }
}
