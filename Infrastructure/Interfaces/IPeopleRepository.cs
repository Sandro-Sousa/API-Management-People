using Entities.Entities;

namespace Repository.Interfaces
{
    public interface IPeopleRepository
    {
        Task<List<People>> GetAllPeople();
        Task<People?> GetByIdPeople(int peopleId);
        Task<People> InsertPeople(People people);
        Task<People?> UpdatePeople(People people);
        Task<bool> DeletePeople(int peopleId);
    }
}
