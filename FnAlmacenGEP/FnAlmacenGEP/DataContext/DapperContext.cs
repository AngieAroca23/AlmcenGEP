using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FnAlmacenGEP.DataContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string conexion;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            conexion = _configuration["ConnectionString"];
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(conexion);
        }
    }
}
