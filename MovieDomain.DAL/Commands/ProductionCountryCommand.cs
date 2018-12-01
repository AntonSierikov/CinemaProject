using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class ProductionCountryCommand : BaseCommand<ProductionCountry, int>, ICountryCommand
    {
        public ProductionCountryCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//
        
        protected override string GenerateInsertQuery(ProductionCountry entity)
        {
            string insert = $@"INSERT INTO {TableName} OUTPUT Inserted.Id VALUES  
                               (@{nameof(entity.iso_3166_1)}, @{nameof(entity.Name)})";
            return insert;
        }

        protected override string GenerateUpdateQuery(ProductionCountry entity)
        {
            string update = $@"UPDATE {TableName} SET 
                              iso_3155_1 = @{nameof(entity.iso_3166_1)},
                              Name = @{nameof(entity.Name)}
                              WHERE Id = @{nameof(entity.Id)}";
            return update;
        }

        //----------------------------------------------------------------//

    }
}
