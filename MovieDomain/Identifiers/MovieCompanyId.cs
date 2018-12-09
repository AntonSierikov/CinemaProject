using MovieDomain.Attributes.Database;

namespace MovieDomain.Identifiers
{
    [ClusteredPrimaryKey]
    public class MovieCompanyId 
    {

        //----------------------------------------------------------------//

        public int MovieId { get; set; }

        public int CompanyId { get; set; }

        //----------------------------------------------------------------//

        public MovieCompanyId(int movieId, int companyId)
        {
            MovieId = movieId;
            CompanyId = companyId;
        }

        //----------------------------------------------------------------//

        public override bool Equals(object obj)
        {
            MovieCompanyId movieCompany = obj as MovieCompanyId;
            if(movieCompany != null)
            {
                return movieCompany.CompanyId.Equals(CompanyId) && movieCompany.MovieId.Equals(MovieId);
            }

            return false;
        }

        //----------------------------------------------------------------//

        public override int GetHashCode()
        {
            return MovieId.GetHashCode() ^ CompanyId.GetHashCode();
        }

        //----------------------------------------------------------------//

    }
}
