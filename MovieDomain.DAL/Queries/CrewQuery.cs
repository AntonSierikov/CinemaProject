using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Mappers;

namespace MovieDomain.DAL.Queries
{
    internal class CrewQuery : BaseQuery<Crew, int>, ICrewQuery
    {

        //----------------------------------------------------------------//

        public CrewQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public CrewQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Crew item)
        {
            return $@"WHERE PeopleId = @{nameof(item.People)} AND MovieId = @{nameof(item.MovieId)} AND JobId = @{nameof(item.JobId)}";
        }

        //----------------------------------------------------------------//

        public async Task<int> GetIdByItem(Crew item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return await _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }
        
        //----------------------------------------------------------------//

        public async Task<IEnumerable<Crew>> GetCrewsWithShortPeopleInfo(int movieId)
        {
            string getCrew = $@"SELECT c.*, j.*, d.*, p.Name, p.Imdb_Id, p.Popularity
                                FROM {TableName} c
                                JOIN Job j ON c.JobId = j.Id 
                                JOIN Department d ON d.Id = j.DepartmentId 
                                JOIN People p ON p.Id = c.PeopleId
                                WHERE c.MovieId = @{nameof(movieId)}";
            return await _connection.QueryAsync<Crew, Job, People, Crew>(getCrew, CreditMapFunc.CrewQueryMap, 
                                                                    new { movieId }, _transaction, splitOn: "Id, Id, Name");
        }

        //----------------------------------------------------------------//

    }
}
