using System;
using System.Collections.Generic;
using System.Text;
using ApiBussinessLogic.Interfaces.Alumno;
using ApiModel.Alumno;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations.Alumno
{
    public class tAlumnoLogic : ITalumnoLogic
    {
        private IUnitOfWork _unitOfWork;

        public tAlumnoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tAlumno GetById(int id)
        {
            return _unitOfWork.ITalumno.GetById(id);
        }

        public tAlumno GetByIdString(string id)
        {
            return _unitOfWork.ITalumno.GetByIdString(id);
        }

        public IEnumerable<tAlumno> GetList()
        {
            return _unitOfWork.ITalumno.GetList();
        }

        public int Insert(tAlumno obj)
        {
            return _unitOfWork.ITalumno.Insert(obj);
        }

        public bool Update(tAlumno obj)
        {
            return _unitOfWork.ITalumno.Update(obj);
        }

        public bool Delete(tAlumno obj)
        {
            return _unitOfWork.ITalumno.Delete(obj);
        }
    }
}
