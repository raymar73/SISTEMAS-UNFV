using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Settings
{
    public enum ERolesUser
    {
        Colaborador = 1,
        Secretaria = 2,
        Supervisor = 3,
        Pagaduria = 4,
        JuntaDeAccionistas = 5,
        Directorio = 6,
        Admin = 7,
        SupervisorDeAdministracion = 8,

    }
    public enum OperationCode
    {
        [Description("Success")]
        Exito = 200,
        [Description("Success without content")]
        ExitoSinContenido = 204,
        [Description("Uncontrolled error")]
        ErrorNotControl = 500,
        [Description("Database error")]
        Informativo = 600,
        [Description("An error ocurred while processing the request")]
        ErrorDataBase = 404,
        [Description("Application error due to business validations")]
        ErrorApp = 900,
       
    }
}
