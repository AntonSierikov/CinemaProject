using System.Data;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using System.Threading.Tasks;

namespace MovieDomain.DAL.Queries
{
    internal class DepartmentQuery : BaseQuery<Department, int>, IDepartmentQuery
    {


        //----------------------------------------------------------------//

        public DepartmentQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public DepartmentQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Department item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Department item)
        {
            return $"WHERE DepartmentName = @{nameof(item.DepartmentName)}";
        }

        //----------------------------------------------------------------//


    }
}
