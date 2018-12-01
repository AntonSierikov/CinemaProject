using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using MovieDomain.DAL.ICommands;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class ProductionCompanyCommand : BaseCommand<ProductionCompany, int>, ICompanyCommand
    {

        //----------------------------------------------------------------//

        public ProductionCompanyCommand(ISession session)
            :base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(ProductionCompany entity)
        {
            return $@"INSERT {TableName} OUTPUT Inserted.Id  VALUES  
                     (@{nameof(entity.Name)})";
        }
        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(ProductionCompany entity)
        {
            return  $@"UPDATE {TableName}  
                       SET Name = @{nameof(entity.Name)}
                       WHERE Id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//

       
    }
}
