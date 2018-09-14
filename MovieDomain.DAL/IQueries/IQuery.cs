using MovieDomain.Abstract;

namespace MovieDomain.DAL.IQueries
{
    public interface IQuery<T, TId> where T: DbObject<TId>
    {
        T GetItem(TId id);

        int Count();

        bool IsExist(T item);
    }
}
