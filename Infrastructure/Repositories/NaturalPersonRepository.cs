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
    public class NaturalPersonRepository : INaturalPersonRepository
    {
        private string? _connectionString;

        public NaturalPersonRepository()
        {
            this._connectionString = Cross.AppSettings.GetConnectionString("Cadastro");
        }

        public async Task<bool> DeleteNaturalPerson(int naturalPersonId)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"NaturalPersonId", naturalPersonId, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                await db.ExecuteAsync("[DeleteNaturalPerson]",
                      parametros,
                      commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<List<NaturalPerson>> GetAllNaturalPerson()
        {
            var resultado = new List<NaturalPerson>();

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<NaturalPerson>(
                    "[GetAllNaturalPerson]",
                    commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    resultado = result.ToList<NaturalPerson>();
                }
            }
            return (resultado);
        }

        public async Task<NaturalPerson> GetNaturalPersonById(int naturalPersonId)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"NaturalPersonId", naturalPersonId, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<NaturalPerson, People, NaturalPerson>(
                "[GetNaturalPersonById]",
                (naturalPerson, people) =>
                {
                    naturalPerson.People = people;
                    return naturalPerson;
                },
                parametros,
                commandType: CommandType.StoredProcedure,
                splitOn: "IdPeople");

                return result.FirstOrDefault() ?? new NaturalPerson();
            }
        }

        public async Task<NaturalPerson> InsertNaturalPerson(NaturalPerson naturalPerson)
        {
            var parametros = new DynamicParameters();

            parametros.Add("@CPF", naturalPerson.CPF, DbType.String, ParameterDirection.Input);
            parametros.Add("@BirthDate", naturalPerson.BirthDate, DbType.Date, ParameterDirection.Input);
            parametros.Add("@PeopleId", naturalPerson.People?.IdPeople, DbType.Int32, ParameterDirection.Input);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<NaturalPerson>("[InsertNaturalPerson]",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return result ?? new NaturalPerson();
            }
        }

        public async Task<NaturalPerson?> UpdateNaturalPerson(NaturalPerson naturalPerson)
        {
            var parametros = new DynamicParameters();

            parametros.Add("@IdNaturalPerson", naturalPerson.IdNaturalPerson, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@CPF", naturalPerson.CPF, DbType.String, ParameterDirection.Input);
            parametros.Add("@BirthDate", naturalPerson.BirthDate, DbType.Date, ParameterDirection.Input);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<NaturalPerson>("[UpdateNaturalPerson]",
                   parametros,
                   commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
