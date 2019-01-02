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
        private string _crewsWithShortPeopleInfoQuery;

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

        public Task<int> GetIdByItem(Crew item)
        {
            string getId = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }

        //----------------------------------------------------------------//

        private string GetCrewsWithShortPeopleInfoQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_crewsWithShortPeopleInfoQuery))
                {
                    _crewsWithShortPeopleInfoQuery = $@"SELECT c.*, j.*, d.*, p.Name, p.Imdb_Id, p.Popularity, p.ProfilePath
                                                        FROM {TableName} c
                                                        JOIN Job j ON c.JobId = j.Id 
                                                        JOIN Department d ON d.Id = j.DepartmentId 
                                                        JOIN People p ON p.Id = c.PeopleId";
                }
                return _crewsWithShortPeopleInfoQuery;
            }
        }

        //----------------------------------------------------------------//

        public Task<IEnumerable<Crew>> GetCrewsWithShortPeopleInfo(int movieId)
        {
            string getCrew = $@"{GetCrewsWithShortPeopleInfoQuery}
                                WHERE c.MovieId = @{nameof(movieId)}";
            return _connection.QueryAsync<Crew, Job, Department, People, Crew>(getCrew, CreditMapFunc.CrewQueryMap, 
                                                                    new { movieId }, _transaction, splitOn: "Id, Id, Name");
        }

        //----------------------------------------------------------------//

        public Task<IEnumerable<Crew>> GetCrewsWithShortPeopleInfo(params int[] movieIds)
        {
            string getCrews = $@"{GetCrewsWithShortPeopleInfoQuery}
                                 WHERE c.MovieId IN @{nameof(movieIds)}";
            return _connection.QueryAsync<Crew, Job, Department, People, Crew>(getCrews, CreditMapFunc.CrewQueryMap,
                                                                    new { movieIds }, _transaction, splitOn: "Id, Id, Name");
        }

        //----------------------------------------------------------------//

    }
}
