using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdenyaDapperProject.Models
{
    public class Context
    {
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

   
        public int Execute(string procedureName, DynamicParameters parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

      
        public List<T> Listele<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(
                    procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

     
        public T Getir<T>(string procedureName, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<T>(
                    procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}