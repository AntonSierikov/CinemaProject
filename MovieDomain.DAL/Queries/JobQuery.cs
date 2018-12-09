using System.Data;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using System.Threading.Tasks;

namespace MovieDomain.DAL.Queries
{
    internal class JobQuery : BaseQuery<Job, int>, IJobQuery
    {

        //----------------------------------------------------------------//
            
        public JobQuery(IDbConnection conneciton) : base(conneciton)
        {}

        //----------------------------------------------------------------//

        public JobQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Job item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Job item)
        {
            return $"WHERE job = @{nameof(item.job)} AND DepartmentId = @{nameof(item.DepartmentId)}";
        }

        //----------------------------------------------------------------//

    }
}
