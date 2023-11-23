using Entities.Entities;
using Service.DTOs;


namespace Service.Interfaces
{
    public interface INaturalPersonService
    {
        Task<List<NaturalPersonDTO>> GetAllNaturalPerson();
        Task<NaturalPersonDTO?> GetNaturalPersonById(int naturalPersonId);
        Task<NaturalPersonDTO?> InsertNaturalPerson(NaturalPersonDTO naturalPersonDTO);
        Task<NaturalPersonDTO?> UpdateNaturalPerson(NaturalPersonDTO naturalPersonDTO);
        Task<bool> DeleteNaturalPerson(int naturalPersonId);
    }
}
