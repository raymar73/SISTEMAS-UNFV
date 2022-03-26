using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Alumno;

namespace ApiBussinessLogic.Interfaces.Alumno
{
    public interface ITalumnoLogic
    {
        bool Update(tAlumno obj);
        int Insert(tAlumno obj);
        IEnumerable<tAlumno> GetList();
        tAlumno GetById(int id);
        tAlumno GetByIdString(string id);
        bool Delete(tAlumno obj);
    }
}
