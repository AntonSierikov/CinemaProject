using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Queries
{
    internal class CompanyQuery : BaseQuery<ProductionCompany, int>, ICompanyQuery
    {

        //----------------------------------------------------------------//

        public CompanyQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public bool IsExist(ProductionCompany item)
        {
            string isExist = $"SELECT Count(*) FROM ProductionCompany WHERE Name = @{nameof(item.Name)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
