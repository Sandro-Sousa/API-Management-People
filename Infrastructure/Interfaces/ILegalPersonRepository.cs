using Entities.Entities;

namespace Repository.Interfaces
{
    public interface ILegalPersonRepository
    {
        Task<LegalPerson?> GetLegalPersonById(int legalPersonId);
        Task<List<LegalPerson>> GetAllLegalPerson();
        Task<LegalPerson> InsertLegalPerson(LegalPerson legalPerson);
        Task<LegalPerson?> UpdateLegalPerson(LegalPerson legalPerson);
        Task<bool> DeleteLegalPerson(int legalPersonId);
    }
}
