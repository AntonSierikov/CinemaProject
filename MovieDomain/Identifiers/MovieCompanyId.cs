namespace MovieDomain.Identifiers
{
    public class MovieCompanyId 
    {

        //----------------------------------------------------------------//

        public int MovieId { get; set; }

        public int CompanyId { get; set; }

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
