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

        public bool Delete(ProductionCountry entity)
        {
            string delete = $"DELETE {TableName} WHERE ProductionCountryId = @{nameof(entity.Id)}";
            return _session.Connection.Execute(delete, entity, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

        public int Insert(ProductionCountry entity)
        {
            string insert = $@"INSERT INTO {TableName} VALUES  OUTPUT Inserted.CountryId
                               (DEFAULT, @{nameof(entity.iso_3166_1)}, @{nameof(entity.Name)})";
            return _session.Connection.ExecuteScalar<int>(insert, entity, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public bool Update(ProductionCountry entity)
        {
            string update = $@"UPDATE {TableName} SET 
                              iso_3155_1 = @{nameof(entity.iso_3166_1)},
                              Name = @{nameof(entity.Name)}
                              WHERE CountryId = @{nameof(entity.Id)}";
            return _session.Connection.Execute(update, entity, _session.Transaction) > default(int);
        }

        protected override string GenerateInsertQuery(ProductionCountry entity)
        {
            string insert = $@"INSERT INTO {TableName} VALUES  OUTPUT Inserted.CountryId
                               (DEFAULT, @{nameof(entity.iso_3166_1)}, @{nameof(entity.Name)})";
            return insert;
        }

        protected override string GenerateUpdateQuery(ProductionCountry entity)
        {
            string update = $@"UPDATE {TableName} SET 
                              iso_3155_1 = @{nameof(entity.iso_3166_1)},
                              Name = @{nameof(entity.Name)}
                              WHERE CountryId = @{nameof(entity.Id)}";
            return update;
        }

        //----------------------------------------------------------------//

    }
}
