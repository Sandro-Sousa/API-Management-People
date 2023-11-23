using Entities.Entities;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IPeopleService
    {
        Task<List<PeopleDTO>> GetAllPeople();
        Task<PeopleDTO?> GetByIdPeople(int peopleId);
        Task<PeopleDTO?> InsertPeople(PeopleDTO peopleDTO);
        Task<PeopleDTO?> UpdatePeople(PeopleDTO peopleDTO);
        Task<bool> DeletePeople(int peopleId);
    }
}
