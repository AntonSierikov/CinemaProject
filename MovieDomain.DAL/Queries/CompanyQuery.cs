using System.Data;
using System.Threading.Tasks;
using Dapper;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Queries
{
    internal class CompanyQuery : BaseQuery<ProductionCompany, int>, ICompanyQuery
    {

        //----------------------------------------------------------------//

        public CompanyQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public CompanyQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(ProductionCompany item) => $"WHERE Name = @{nameof(item.Name)}";

       //----------------------------------------------------------------//

        public Task<int> GetIdByItem(ProductionCompany item)
        {
            string getId = $"SELECT TOP 1 Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }

        //----------------------------------------------------------------//

    }
}
