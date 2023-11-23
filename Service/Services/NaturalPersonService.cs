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
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly IMapper _mapper;
        private readonly INaturalPersonRepository _naturalPersonRepository;
        private readonly IPeopleRepository _peopleRepository;

        public NaturalPersonService(IMapper mapper, INaturalPersonRepository naturalPersonRepository, IPeopleRepository peopleRepository)
        {
            this._mapper = mapper;
            this._naturalPersonRepository = naturalPersonRepository;
            this._peopleRepository = peopleRepository;
        }

        public async Task<bool> DeleteNaturalPerson(int naturalPersonId)
        {
            if (naturalPersonId < 0)
            {
                return false;
            }
            try
            {
                var idNaturalPerson = await this._naturalPersonRepository.GetNaturalPersonById(naturalPersonId);

                if (idNaturalPerson != null && idNaturalPerson.People != null && idNaturalPerson.People.IdPeople != null)
                {
                    var deleteNaturalPerson = await this._naturalPersonRepository.DeleteNaturalPerson(naturalPersonId);
                    var result = await this._peopleRepository.DeletePeople(idNaturalPerson.People.IdPeople.Value);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<NaturalPersonDTO>> GetAllNaturalPerson()
        {
            try
            {
                var naturalPeoples = await this._naturalPersonRepository.GetAllNaturalPerson();

                var result = this._mapper.Map<List<NaturalPersonDTO>>(naturalPeoples);

                if (naturalPeoples == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NaturalPersonDTO?> GetNaturalPersonById(int naturalPersonId)
        {
            try
            {
                var people = await this._naturalPersonRepository.GetNaturalPersonById(naturalPersonId);

                if (people == null) throw new Exception("Id inválido(s).");

                var result = this._mapper.Map<NaturalPersonDTO>(people);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NaturalPersonDTO?> InsertNaturalPerson(NaturalPersonDTO naturalPersonDTO)
        {
            try
            {
                var dataPeople = this._mapper.Map<People>(naturalPersonDTO.People);

                var peopleEntity = await this._peopleRepository.InsertPeople(dataPeople);

                var data = this._mapper.Map<NaturalPerson>(naturalPersonDTO);

                var naturalPerson = await this._naturalPersonRepository.InsertNaturalPerson(data);

                if (peopleEntity != null)
                {
                    naturalPerson.People = peopleEntity;
                }

                var result = this._mapper.Map<NaturalPersonDTO>(naturalPerson);

                if (naturalPerson == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NaturalPersonDTO?> UpdateNaturalPerson(NaturalPersonDTO naturalPersonDTO)
        {
            try
            {
                var data = this._mapper.Map<NaturalPerson>(naturalPersonDTO);

                var getNaturalPerson = await this._naturalPersonRepository.GetNaturalPersonById(data.IdNaturalPerson);

                var peopleAux = new People
                {
                    IdPeople = getNaturalPerson.People.IdPeople,
                    Name = data.People.Name,
                    LastName = data.People.LastName,
                    Email = data.People.Email,
                    Phone = data.People.Phone,
                    Address = data.People.Address,
                    City = data.People.City,
                    State = data.People.State,
                    Country = data.People.Country,
                    ZipCode = data.People.ZipCode,
                    Age = data.People.Age
                };

                var updatePerson = await this._peopleRepository.UpdatePeople(peopleAux);

                var people = await this._naturalPersonRepository.UpdateNaturalPerson(data);

                if (people != null && updatePerson != null)
                {
                    people.People = updatePerson;
                }

                var result = this._mapper.Map<NaturalPersonDTO>(people);

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
