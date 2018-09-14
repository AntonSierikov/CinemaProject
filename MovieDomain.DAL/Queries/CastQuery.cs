using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class CastQuery : BaseQuery<Cast, int>, ICastQuery
    {


        //----------------------------------------------------------------//

        public CastQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public bool IsExist(Cast item)
        {
            string isExist = $"SELECT Count(*) FROM Cast WHERE CharacterCast = @{nameof(item.CharacterCast)} AND PeopleId = @{nameof(item.PeopleId)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
