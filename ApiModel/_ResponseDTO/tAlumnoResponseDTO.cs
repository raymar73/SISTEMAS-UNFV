using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Alumno;
using Dapper.Contrib.Extensions;

namespace ApiModel._ResponseDTO
{
    public class tAlumnoResponseDTO
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


        public tAlumnoResponseDTO Mapper(tAlumnoResponseDTO dto, tAlumno obj)
        {
            dto.CodAlumno = obj.CodAlumno;
            dto.ApPaterno = obj.ApPaterno;
            dto.ApMaterno = obj.ApMaterno;
            dto.Nombres = obj.Nombres;
            dto.DNI = obj.DNI;
            dto.Genero = obj.Genero;
            dto.FechaNacimiento = obj.FechaNacimiento;
            dto.DptoNacimiento = obj.DptoNacimiento;
            dto.ProvNacimiento = obj.ProvNacimiento;
            dto.DistNacimiento = obj.DistNacimiento;
            dto.DireccionDomicilio = obj.DireccionDomicilio;
            dto.NumTelefono = obj.NumTelefono;
            dto.NumCelular = obj.NumCelular;
            dto.EmailAlumno = obj.EmailAlumno;
            dto.AnioIngreso = obj.AnioIngreso;
            dto.IdCarrera = obj.IdCarrera;
            dto.FotoAlumno = obj.FotoAlumno;
            dto.FirmaAlumno = obj.FirmaAlumno;
            return dto;
        }
    }
}
