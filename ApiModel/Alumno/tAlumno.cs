using System;
using System.Collections.Generic;
using System.Text;
using ApiModel._RequestDTO;
using Dapper.Contrib.Extensions;

namespace ApiModel.Alumno
{
    public class tAlumno
    {
        [ExplicitKey]
        public string CodAlumno { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public string Genero { get; set; }
        public double? FechaNacimiento { get; set; }
        public int? DptoNacimiento { get; set; }
        public int? ProvNacimiento { get; set; }
        public int? DistNacimiento { get; set; }
        public string DireccionDomicilio { get; set; }
        public string NumTelefono { get; set; }
        public string NumCelular { get; set; }
        public string EmailAlumno { get; set; }
        public int? AnioIngreso { get; set; }
        public int? IdCarrera { get; set; }
        public string FotoAlumno { get; set; }
        public string FirmaAlumno { get; set; }

        public tAlumno Mapper(tAlumno obj, tAlumnoRequestDTO dto)
        {
            obj.CodAlumno = dto.CodAlumno;
            obj.ApPaterno = dto.ApPaterno;
            obj.ApMaterno = dto.ApMaterno;
            obj.Nombres = dto.Nombres;
            obj.DNI = dto.DNI;
            obj.Genero = dto.Genero;
            obj.FechaNacimiento = dto.FechaNacimiento;
            obj.DptoNacimiento = dto.DptoNacimiento;
            obj.ProvNacimiento = dto.ProvNacimiento;
            obj.DistNacimiento = dto.DistNacimiento;
            obj.DireccionDomicilio = dto.DireccionDomicilio;
            obj.NumTelefono = dto.NumTelefono;
            obj.NumCelular = dto.NumCelular;
            obj.EmailAlumno = dto.EmailAlumno;
            obj.AnioIngreso = dto.AnioIngreso;
            obj.IdCarrera = dto.IdCarrera;
            obj.FotoAlumno = dto.FotoAlumno;
            obj.FirmaAlumno = dto.FirmaAlumno;

            return obj;
        }
    }
}
