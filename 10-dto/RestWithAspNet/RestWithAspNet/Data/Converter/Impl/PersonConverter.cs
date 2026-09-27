using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Data.DTO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Data.Converter.Impl
{
    public class PersonConverter : IParser<PersonDTO, Person>, IParser<Person, PersonDTO>
    {
        // Converte de PersonDTO => Person
        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
            };
        }

        // Converte de Person => PersonDTO
        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonDTO { 
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };

        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if(origin ==null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
