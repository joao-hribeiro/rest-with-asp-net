using RestWithAspNet.Data.DTO;

namespace RestWithAspNet.Services
{
    public interface IPersonServices
    {
        PersonDTO Create(PersonDTO PersonDTO);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        void Delete(long id);
        void Exists(long id);
    }
}
