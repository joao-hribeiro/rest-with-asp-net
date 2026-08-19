using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repositories;

namespace RestWithAspNet.Services.Impl
{
    public class PersonSerivecesImpl : IPersonServices
    {
        private readonly IPersonRepository _repository;
        public PersonSerivecesImpl(IPersonRepository repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person FindById(long id) 
        {
            return _repository.FindById(id);
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
    