using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repositories;

namespace RestWithAspNet.Services.Impl
{
    public class PersonSerivecesImpl : IPersonServices
    {
        private readonly IRepository<Person> _personRepository;
        public PersonSerivecesImpl(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(long id) 
        {
            return _personRepository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public void Exists(long id)
        {
            _personRepository.Exists(id);
        }
    }
}
    