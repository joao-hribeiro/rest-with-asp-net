using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Impl
{
    public class PersonSerivecesImpl : IPersonServices
    {
        public Person FindById(long id)
        {
            return MockPerson(id);
        }
        public List<Person> FindAll()
        {
            List<Person> list = new List<Person>();
            for (int i = 0; i < 8; i++) list.Add(MockPerson(i));
            return list;
        }
        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000); 
            return person;
        }
        public Person Update(Person person)
        {
            return person;
        }
        public void Delete(long id)
        {
            // Lógica para deletar aqui
        }

        private Person MockPerson(long id) // Criar pessoa com ID aleatório
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "João" + id,
                LastName = "Ribeiro" + id,
                Adress = "123 Rua abc" + id,
            };
            person.Gender = (id % 2 == 0) ? 'M' : 'F';
            return person;
        }
    }
}
