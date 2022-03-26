using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ApiModel.Login;
using ApiRepositories.Login;
using Dapper;

namespace ApiDataAccess.Login
{
    public class credencialesRepository : Repository<CredencialesUsuaroBE>, ICredencialesRepository
    {
        public credencialesRepository(string _connectionString) : base(_connectionString)
        {
        }

        public bool LoguearUsuario(CredencialesUsuaroBE usuario)
        {
            int validate = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@username", usuario.CodigoUsuario + "@unfv.edu.pe");
            using (var connection = new SqlConnection(_connectionString))
            {
                validate = connection.Query<int>("[dbo].[sp_getUser]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return (validate == 1);
        }
    }
}
