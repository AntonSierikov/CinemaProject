using System.Data;
using MovieDomain.DAL.Factories;

namespace MovieDomain.DAL.Abstract
{
    internal abstract class BaseDBOperation<T> where T: class
    {

        protected readonly ISession _session;

        protected readonly string TableName;

        //----------------------------------------------------------------//

        public BaseDBOperation(ISession session)
        {
            _session = session;
            TableName = TableFactory.GetNameTable<T>();
        }

        //----------------------------------------------------------------//

    }
}
