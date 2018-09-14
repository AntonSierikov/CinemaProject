using System;
using System.Collections.Generic;
using System.Text;
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

        public bool IsExist(Crew item)
        {
            string isExist = $@"SELECT Count(*) FROM Crew WHERE PeopleId = @{nameof(item.People)} 
                                AND MovieId = @{nameof(item.MovieId)}, JobId = @{nameof(item.JobId)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item, _session.Transaction) > default(int);
        }
        
        //----------------------------------------------------------------//

    }
}
