using System.Threading.Tasks;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class CrewQuery : BaseQuery<Crew, int>, ICrewQuery
    {

        //----------------------------------------------------------------//

        public CrewQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Crew item)
        {
            return @"WHERE PeopleId = @{nameof(item.People)} AND MovieId = @{nameof(item.MovieId)}, JobId = @{ nameof(item.JobId)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Crew item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getId, item, _session.Transaction);
        }
        
        //----------------------------------------------------------------//

    }
}
