using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Alumno;
using ApiRepositories.Alumno;

namespace ApiDataAccess.Alumno
{
    public class tAlumnoRepository : Repository<tAlumno>, ITalumnoRepository
    {
        public tAlumnoRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
