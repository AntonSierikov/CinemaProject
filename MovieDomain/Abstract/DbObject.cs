using System;
using MovieDomain.Attributes.Database;

namespace MovieDomain.Abstract
{
    [PrimaryKey(ColumnName = nameof(Id))]
    [Serializable]
    public class DbObject<T>
    {
        public T Id { get; set; }

    }
}
