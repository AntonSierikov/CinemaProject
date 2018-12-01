using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class CountryQuery : BaseQuery<ProductionCountry, int>, ICountryQuery
    {

        //----------------------------------------------------------------//

        public CountryQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(ProductionCountry item)
        {
            return $"WHERE Name = @{nameof(item.Name)} AND iso_3166_1 = @{nameof(item.iso_3166_1)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(ProductionCountry item)
        {
            string getId = $"SELECT TOP 1 Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getId, item, _session.Transaction);
        }

        //----------------------------------------------------------------//

    }
}
