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
    public class PeopleService : IPeopleService
    {
        private readonly IMapper _mapper;
        private readonly IPeopleRepository _peopleRepository;
        
        public PeopleService(IMapper mapper, IPeopleRepository peopleRepository)
        {
            this._mapper = mapper;
            this._peopleRepository = peopleRepository;
        }
        public async Task<bool> DeletePeople(int peopleId)
        {
            if (peopleId < 0)
            {
                return false;
            }
            try
            {
                var result = await this._peopleRepository.DeletePeople(peopleId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PeopleDTO>> GetAllPeople()
        {
            try
            {
                var peoples = await this._peopleRepository.GetAllPeople();

                var result = this._mapper.Map<List<PeopleDTO>>(peoples);

                if (peoples == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PeopleDTO?> GetByIdPeople(int peopleId)
        {
            try
            {
                var people = await this._peopleRepository.GetByIdPeople(peopleId);

                if (people == null) throw new Exception("Id inválido(s).");

                var result = this._mapper.Map<PeopleDTO>(people);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PeopleDTO?> InsertPeople(PeopleDTO peopleDTO)
        {
            try
            {
                var data = this._mapper.Map<People>(peopleDTO);

                var user = await this._peopleRepository.InsertPeople(data);

                var result = this._mapper.Map<PeopleDTO>(user);

                if (user == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PeopleDTO?> UpdatePeople(PeopleDTO peopleDTO)
        {
            try
            {
                var data = this._mapper.Map<People>(peopleDTO);

                var people = await this._peopleRepository.UpdatePeople(data);

                var result = this._mapper.Map<PeopleDTO>(people);

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
