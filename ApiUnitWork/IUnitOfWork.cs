using ApiRepositories.Alumno;
using ApiRepositories.Login;

namespace ApiUnitWork
{
    using ApiRepositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IUnitOfWork
    {
        ICredencialesRepository ICredenciales { get; }
        ITalumnoRepository ITalumno { get; }
    }
}
