using Entities.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Repository.Repositories
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        private string? _connectionString;

        public LegalPersonRepository()
        {
            this._connectionString = Cross.AppSettings.GetConnectionString("Cadastro");
        }

        public async Task<bool> DeleteLegalPerson(int legalPersonId)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"LegalPersonId", legalPersonId, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                await db.ExecuteAsync("[DeleteLegalPerson]",
                      parametros,
                      commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<List<LegalPerson>> GetAllLegalPerson()
        {
            var resultado = new List<LegalPerson>();

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<LegalPerson>(
                    "[GetAllLegalPerson]",
                    commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    resultado = result.ToList<LegalPerson>();
                }
            }
            return (resultado);
        }

        public async Task<LegalPerson?> GetLegalPersonById(int legalPersonId)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"IdLegalPerson", legalPersonId, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<LegalPerson, People, LegalPerson>(
                "[GetLegalPersonById]",
                (legalPerson, people) =>
                {
                    legalPerson.People = people;
                    return legalPerson;
                },
                parametros,
                commandType: CommandType.StoredProcedure,
                splitOn: "IdPeople");

                return result.FirstOrDefault();
            }
        }

        public async Task<LegalPerson> InsertLegalPerson(LegalPerson legalPerson)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"CNPJ", legalPerson.CNPJ, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"OpeningDate", legalPerson.OpeningDate, DbType.DateTime, ParameterDirection.Input, null);
            parametros.Add(@"CompanyName", legalPerson.CompanyName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"TradingName", legalPerson.TradingName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"RegistrationStatus", legalPerson.RegistrationStatus, DbType.String, ParameterDirection.Input, null);
            parametros.Add("@PeopleId", legalPerson.People?.IdPeople, DbType.Int32, ParameterDirection.Input);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<LegalPerson>("[InsertLegalPerson]",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return result ?? new LegalPerson();
            }
        }

        public async Task<LegalPerson?> UpdateLegalPerson(LegalPerson legalPerson)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"LegalPersonId", legalPerson.IdLegalPerson, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add(@"CNPJ", legalPerson.CNPJ, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"OpeningDate", legalPerson.OpeningDate, DbType.DateTime, ParameterDirection.Input, null);
            parametros.Add(@"CompanyName", legalPerson.CompanyName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"TradingName", legalPerson.TradingName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"RegistrationStatus", legalPerson.RegistrationStatus, DbType.String, ParameterDirection.Input, null);
            parametros.Add("@PeopleId", legalPerson.People?.IdPeople, DbType.Int32, ParameterDirection.Input);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<LegalPerson>("[UpdateLegalPerson]",
                  parametros,
                  commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
