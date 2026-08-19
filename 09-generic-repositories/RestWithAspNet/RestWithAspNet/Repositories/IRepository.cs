using RestWithAspNet.Model;
using RestWithAspNet.Model.Base;

namespace RestWithAspNet.Repositories
{
    public interface IRepository<T> where T : BaseEntity 
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
