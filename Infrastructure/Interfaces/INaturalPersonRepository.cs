using Entities.Entities;


namespace Repository.Interfaces
{
    public interface INaturalPersonRepository
    {
        Task<List<NaturalPerson>> GetAllNaturalPerson();
        Task<NaturalPerson> GetNaturalPersonById(int naturalPersonId);
        Task<NaturalPerson> InsertNaturalPerson(NaturalPerson naturalPerson);
        Task<NaturalPerson?> UpdateNaturalPerson(NaturalPerson naturalPerson);
        Task<bool> DeleteNaturalPerson(int naturalPersonId);
    }
}
