using System.Threading.Tasks;

namespace ResEvi.Contracts
{
    internal interface IDAO<T>
    {
        Task<T> Get(long id);

        Task<T> Save(T entity);

        Task<T> Update(T entity);

        Task Delete(long id);
    }
}
