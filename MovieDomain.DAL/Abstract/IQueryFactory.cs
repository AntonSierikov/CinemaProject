using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.DAL.Abstract
{
    public interface IQueryFactory
    {
        T CreateQuery<T>(ISession session);
    }
}
