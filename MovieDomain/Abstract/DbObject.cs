using System;

namespace MovieDomain.Abstract
{
    [Serializable]
    public class DbObject<T>
    {
        public T Id { get; set; }

    }
}
