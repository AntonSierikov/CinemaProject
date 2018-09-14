using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class CountryQuery : BaseQuery<ProductionCountry, int>, IQuery<ProductionCountry, int>
    {

        //----------------------------------------------------------------//

        public CountryQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public bool IsExist(ProductionCountry item)
        {
            string isExist = $"SELECT Count(*) FROM ProductionCountry WHERE Name = @{nameof(item.Name)} AND iso_3166_1 = @{nameof(item.iso_3166_1)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
