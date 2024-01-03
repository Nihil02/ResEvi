using System.Threading.Tasks;

namespace ResEvi.Contracts 
{
    internal interface IDAO<T> 
    {
        public Task<T> Get(long id);
        public Task<T> Save(T entity);
        public Task<T> Update(T entity);
        public void Delete(long id);
    }
}