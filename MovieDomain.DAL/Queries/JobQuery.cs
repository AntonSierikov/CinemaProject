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

        public JobQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Job item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getId, item, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Job item)
        {
            return $"WHERE job = @{nameof(item.job)} AND Department = @{nameof(item.Department)}";
        }

        //----------------------------------------------------------------//

    }
}
