using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Abstract;

namespace MovieDomain.EqualityComparers
{
    public class BaseDbEqualityComparer<TKey> : IEqualityComparer<DbObject<TKey>>
    {
        public bool Equals(DbObject<TKey> x, DbObject<TKey> y) => x.Id.Equals(y.Id);

        public int GetHashCode(DbObject<TKey> obj) => obj.Id.GetHashCode();
    }
}
