using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Queries
{
    internal class PeopleQuery : BaseQuery<People, int>, IPeopleQuery
    {

        //----------------------------------------------------------------//

        public PeopleQuery(ISession session) : base(session)
        {
        }


        //----------------------------------------------------------------//

        public bool IsExist(People item)
        {
            string exist = $@"SELECT COUNT(*) FROM {TableName} WHERE Name = @{nameof(item.Name)} AND 
                              Birthday = @{nameof(item.Birthday)} AND PlaceOfBirth = @{nameof(item.PlaceOfBirth)}";
            return _session.Connection.QueryFirstOrDefault<int>(exist, item, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
