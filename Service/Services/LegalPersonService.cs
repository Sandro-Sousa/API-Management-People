using AutoMapper;
using Entities.Entities;
using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly IMapper _mapper;
        private readonly ILegalPersonRepository _legalPersonRepository;
        private readonly IPeopleRepository _peopleRepository;
        
        public LegalPersonService(IMapper mapper, ILegalPersonRepository legalPersonRepository, IPeopleRepository peopleRepository)
        {
            this._mapper = mapper;
            this._legalPersonRepository = legalPersonRepository;
            this._peopleRepository = peopleRepository;
        }
        public async Task<bool> DeleteLegalPerson(int legalPersonId)
        {
            if (legalPersonId < 0)
            {
                return false;
            }
            try
            {
                var idlegalPerson = await this._legalPersonRepository.GetLegalPersonById(legalPersonId);
                var result = await this._peopleRepository.DeletePeople(legalPersonId);

                if (idlegalPerson != null && idlegalPerson.People != null && idlegalPerson.People.IdPeople != null)
                {
                    var deletePerson = await this._legalPersonRepository.DeleteLegalPerson(idlegalPerson.People.IdPeople.Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LegalPersonDTO>> GetAllLegalPerson()
        {
            try
            {
                var legalPeoples = await this._legalPersonRepository.GetAllLegalPerson();

                var result = this._mapper.Map<List<LegalPersonDTO>>(legalPeoples);

                if (legalPeoples == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LegalPersonDTO?> GetLegalPersonById(int legalPersonId)
        {
            try
            {
                var legalPeople = await this._legalPersonRepository.GetLegalPersonById(legalPersonId);

                var result = this._mapper.Map<LegalPersonDTO>(legalPeople);

                if (legalPeople == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<LegalPersonDTO?> InsertLegalPerson(LegalPersonDTO legalPersonDTO)
        {
            try
            {
                var dataPeople = this._mapper.Map<People>(legalPersonDTO.People);

                var peopleEntity = await this._peopleRepository.InsertPeople(dataPeople);

                var data = this._mapper.Map<LegalPerson>(legalPersonDTO);

                var naturalPerson = await this._legalPersonRepository.InsertLegalPerson(data);

                if (peopleEntity != null)
                {
                    naturalPerson.People = peopleEntity;
                }

                var result = this._mapper.Map<LegalPersonDTO>(naturalPerson);

                if (naturalPerson == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LegalPersonDTO?> UpdateLegalPerson(LegalPersonDTO legalPersonDTO)
        {
            try
            {
                var data = this._mapper.Map<LegalPerson>(legalPersonDTO);

                var getgLegalPerson = await this._legalPersonRepository.GetLegalPersonById(data.IdLegalPerson);

                var peopleAux = new People
                {
                    IdPeople = getgLegalPerson?.People?.IdPeople,
                    Name = data?.People?.Name,
                    LastName = data?.People?.LastName,
                    Email = data?.People?.Email,
                    Phone = data?.People?.Phone,
                    Address = data?.People?.Address,
                    City = data?.People?.City,
                    State = data?.People?.State,
                    Country = data?.People?.Country,
                    ZipCode = data?.People?.ZipCode,
                    Age = data.People.Age
                };


                var updatePerson = await this._peopleRepository.UpdatePeople(peopleAux);

                var people = await this._legalPersonRepository.UpdateLegalPerson(data);

                if (people != null && updatePerson != null)
                {
                    people.People = updatePerson;
                }
                var result = this._mapper.Map<LegalPersonDTO>(people);

                if (people == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
