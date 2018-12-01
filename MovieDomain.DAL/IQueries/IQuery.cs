using System.Threading.Tasks;
using MovieDomain.Abstract;

namespace MovieDomain.DAL.IQueries
{
    public interface IQuery<T, TId> where T: DbObject<TId>
    {
        Task<T> GetItem(TId id);

        Task<int> Count();

        Task<bool> IsExist(T item);

        Task<TId> GetIdByItem(T item);
    }
}
