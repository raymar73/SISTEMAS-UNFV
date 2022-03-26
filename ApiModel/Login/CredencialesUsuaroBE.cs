using System;
using System.Collections.Generic;
using System.Text;
using ApiModel._RequestDTO;

namespace ApiModel.Login
{
    public class CredencialesUsuaroBE
    {
        public string CodigoUsuario { get; set; }
        /*public string PasswordUsuario { get; set; }
        public string Token { get; set; }*/

        public CredencialesUsuaroBE Mapper(CredencialesUsuaroBE obj, CredencialesRequestDTO dto)
        {
            obj.CodigoUsuario = dto.CodigoUsuario;
            /*obj.PasswordUsuario = dto.PasswordUsuario;
            obj.Token = dto.Token;*/
            return obj;
        }
    }
}
