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

        public MovieCompany(Movie movie, ProductionCompany company)
        {
            Movie = movie;
            Company = company;
            Id.MovieId = movie.Id;
            Id.CompanyId = company.Id;
        }

        //----------------------------------------------------------------//

    }
}
