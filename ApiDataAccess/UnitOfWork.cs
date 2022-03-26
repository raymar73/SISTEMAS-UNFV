using ApiRepositories;
using ApiUnitWork;
using System;
using System.Collections.Generic;
using System.Text;
using ApiDataAccess.Alumno;
using ApiDataAccess.Login;
using ApiRepositories.Alumno;
using ApiRepositories.Login;
using Nest;


namespace ApiDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICredencialesRepository ICredenciales { get; }
        public ITalumnoRepository ITalumno { get; }

        public UnitOfWork(string connectionString)
        {
            ICredenciales = new credencialesRepository(connectionString);
            ITalumno = new tAlumnoRepository(connectionString);
        }

        
    }
}
