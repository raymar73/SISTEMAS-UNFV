using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace ApiModel._RequestDTO
{
    public class tAlumnoRequestDTO
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
    }
}
