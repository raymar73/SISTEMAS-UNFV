using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Login;

namespace ApiRepositories.Login
{
    public interface ICredencialesRepository : IRepository<CredencialesUsuaroBE>
    {
        bool LoguearUsuario(CredencialesUsuaroBE usuario);
    }
}
