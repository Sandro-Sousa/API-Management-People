using Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Interfaces;
using Service.Services;

namespace WebAPIs.Controllers
{
    [ApiController]
    [Route("api/Management")]
    public class ManagementPeopleController : Controller
    {
        private readonly ILegalPersonService _legalPersonService;
        private readonly INaturalPersonService _naturalPersonService;
        private readonly IPeopleService _peopleService;

       
        public ManagementPeopleController(ILegalPersonService legalPersonService, INaturalPersonService naturalPersonService, IPeopleService peopleService)
        {
            this._legalPersonService = legalPersonService;
            this._naturalPersonService = naturalPersonService;
            this._peopleService = peopleService;
        }

        #region endPoints de Pessoas Físicas
        [HttpGet("v1/naturalPersonGetAll")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> NaturalPersonGetAll()
        {
            try
            {
                var result = await this._naturalPersonService.GetAllNaturalPerson();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/getNaturalPersonById/{naturalPersonId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> GetNaturalPersonById(int naturalPersonId)
        {
            try
            {
                var result = await this._naturalPersonService.GetNaturalPersonById(naturalPersonId);

                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/insertNaturalPerson")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserido com Sucesso", typeof(NaturalPersonDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> InsertNaturalPerson(NaturalPersonDTO naturalPersonDTO)
        {
            try
            {
                var result = await this._naturalPersonService.InsertNaturalPerson(naturalPersonDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/updateNaturalPerson/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Atualizado com Sucesso", typeof(NaturalPersonDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> UpdateNaturalPerson(int id, NaturalPersonDTO naturalPersonDTO)
        {
            if (id != naturalPersonDTO.IdNaturalPerson)
            {
                return BadRequest("Id Invalido");
            }
            try
            {
                var result = await this._naturalPersonService.UpdateNaturalPerson(naturalPersonDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/deleteNaturalPerson/{naturalPersonId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> DeleteNaturalPerson(int naturalPersonId)
        {
            try
            {
                var result = await this._naturalPersonService.DeleteNaturalPerson(naturalPersonId);

                if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

        #region endPoints de Pessoas Jurídicas
        [HttpGet("v1/getAllLegalPerson")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> GetAllLegalPerson()
        {
            try
            {
                var result = await this._legalPersonService.GetAllLegalPerson();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/getLegalPersonById/{legalPersonId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> GetLegalPersonById(int legalPersonId)
        {
            try
            {
                var result = await this._legalPersonService.GetLegalPersonById(legalPersonId);

                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/insertLegalPerson")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserido com Sucesso", typeof(LegalPersonDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> InsertLegalPerson(LegalPersonDTO legalPersonDTO)
        {
            try
            {
                var result = await this._legalPersonService.InsertLegalPerson(legalPersonDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/updateLegalPerson/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Atualizado com Sucesso", typeof(LegalPersonDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> UpdateLegalPerson(int id, LegalPersonDTO legalPersonDTO)
        {
            if (id != legalPersonDTO.LegalPersonId)
            {
                return BadRequest("Id Invalido");
            }
            try
            {
                var result = await this._legalPersonService.UpdateLegalPerson(legalPersonDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/DeleteLegalPersonById/{naturalPersonId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
        public async Task<ActionResult> DeleteLegalPersonById(int legalPersonId)
        {
            try
            {
                var result = await this._legalPersonService.DeleteLegalPerson(legalPersonId);

                if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
