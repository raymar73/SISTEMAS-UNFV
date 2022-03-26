using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Login;

namespace ApiBussinessLogic.Interfaces.Login
{
    public interface ICredencialesLogic
    {
        bool LoguearUsuario(CredencialesUsuaroBE usuario);
    }
}
