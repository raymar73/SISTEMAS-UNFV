using System;
using System.Collections.Generic;
using System.Text;
using ApiBussinessLogic.Interfaces.Login;
using ApiModel.Login;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations.Login
{
    public class credencialesLogic : ICredencialesLogic
    {
        private IUnitOfWork _unitOfWork;

        public credencialesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool LoguearUsuario(CredencialesUsuaroBE usuario)
        {
            return _unitOfWork.ICredenciales.LoguearUsuario(usuario);
        }
    }
}
