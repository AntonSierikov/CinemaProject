using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using MovieDomain.DAL.ICommands;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class ProductionCompanyCommand : BaseCommand<ProductionCompany, int>, ICommand<ProductionCompany, int>
    {

        //----------------------------------------------------------------//

        public ProductionCompanyCommand(ISession session)
            :base(session)
        {}

        //----------------------------------------------------------------//

        public int Insert(ProductionCompany entity)
        {
            string insert = $@"INSERT {TableConstans.PRODUCTION_COMPANY} VALUES  OUTPUT Inserted.CompanyId
                               (DEFAULT, @{nameof(entity.Name)}";
            return _session.Connection.ExecuteScalar<int>(insert, entity, _session.Transaction);
        }

        //----------------------------------------------------------------//

        protected override int UpdateEntity(ProductionCompany entity)
        {
            string update = $@"UPDATE {TableConstans.PRODUCTION_COMPANY} SET 
                               SET Name = @{nameof(entity.Name)}
                               WHERE CompanyId = @{nameof(entity.Id)}";
            return _session.Connection.Execute(update, _session.Transaction);
        }

        //----------------------------------------------------------------//

       
    }
}
