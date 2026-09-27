using RestWithAspNet.Data.Converter.Impl;
using RestWithAspNet.Data.DTO;
using RestWithAspNet.Model;
using RestWithAspNet.Repositories;

namespace RestWithAspNet.Services.Impl
{
    public class PersonSerivecesImpl : IPersonServices
    {
        private readonly IRepository<Person> _personRepository;
        private readonly PersonConverter _converter;
        public PersonSerivecesImpl(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_personRepository.FindAll());
        }

        public PersonDTO FindById(long id) 
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            _personRepository.Create(entity);
            return _converter.Parse(entity);
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            _personRepository.Update(entity);
            return _converter.Parse(entity);
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
    