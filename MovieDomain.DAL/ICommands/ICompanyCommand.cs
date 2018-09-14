using MovieDomain.Entities;

namespace MovieDomain.DAL.ICommands
{
    public interface ICompanyCommand : ICommand<ProductionCompany, int>
    {
    }
}
