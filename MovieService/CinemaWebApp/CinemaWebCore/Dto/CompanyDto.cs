namespace CinemaWebCore.Dto
{
    public class CompanyDto
    {
        public readonly int CompanyId;
        public readonly string CompanyName;

        //----------------------------------------------------------------//

        public CompanyDto(int _companyId, string _companyName)
        {
            CompanyId = _companyId;
            CompanyName = _companyName;
        }

        //----------------------------------------------------------------//

    }
}
