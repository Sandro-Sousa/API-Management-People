using System.Data.SqlClient;
using System.Data;
using Entities.Entities;
using Repository.Interfaces;
using Dapper;


namespace ManagmentPeople.Infra
{
    public class PeopleRepository : IPeopleRepository
    {
        private string? _connectionString;

        public PeopleRepository()
        {
            this._connectionString = Cross.AppSettings.GetConnectionString("Cadastro");
        }

        public async Task<bool> DeletePeople(int idPeople)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"IdPeople", idPeople, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                await db.ExecuteAsync("[DeletePeople]",
                      parametros,
                      commandType: CommandType.StoredProcedure);

                return true;
            }
        }

        public async Task<List<People>> GetAllPeople()
        {
            var resultado = new List<People>();

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<People>(
                    "[GetAllPeople]",
                    commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    resultado = result.ToList<People>();
                }
            }
            return (resultado);
        }

        public async Task<People?> GetByIdPeople(int peopleId)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"ClienteId", peopleId, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<People>(
                    "[GetByIdPeople]",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return result != null ? result.ToList().FirstOrDefault() : null;
            }
        }

        public async Task<People?> InsertPeople(People people)
        {   
            
            var parametros = new DynamicParameters();

            parametros.Add(@"Name", people.Name, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"LastName", people.LastName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Email", people.Email, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Phone", people.Phone, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Address", people.Address, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"City", people.City, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"State", people.State, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Country", people.Country, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"ZipCode", people.ZipCode, DbType.String, ParameterDirection.Input, null);  
            parametros.Add(@"Age", people.Age, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<People>("[InsertPeople]",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return result;

            }
        }

        public async Task<People?> UpdatePeople(People people)
        {
            
            var parametros = new DynamicParameters();

            parametros.Add(@"IdPeople", people.IdPeople, DbType.Int32, ParameterDirection.Input, null);
            parametros.Add(@"Name", people.Name, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"LastName", people.LastName, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Email", people.Email, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Phone", people.Phone, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Address", people.Address, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"City", people.City, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"State", people.State, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"Country", people.Country, DbType.String, ParameterDirection.Input, null);
            parametros.Add(@"ZipCode", people.ZipCode, DbType.String, ParameterDirection.Input, null);  
            parametros.Add(@"Age", people.Age, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryFirstOrDefaultAsync<People>("[UpdatePeople]",
                   parametros,
                   commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
