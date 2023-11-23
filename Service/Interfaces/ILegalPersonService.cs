using Entities.Entities;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface ILegalPersonService
    {
        Task<LegalPersonDTO?> GetLegalPersonById(int legalPersonId);
        Task<List<LegalPersonDTO>> GetAllLegalPerson();
        Task<LegalPersonDTO?> InsertLegalPerson(LegalPersonDTO legalPersonDTO);
        Task<LegalPersonDTO?> UpdateLegalPerson(LegalPersonDTO legalPersonDTO);
        Task<bool> DeleteLegalPerson(int legalPersonId);
    }
}
