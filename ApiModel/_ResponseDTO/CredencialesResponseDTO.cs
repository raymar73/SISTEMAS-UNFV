using System;
using System.Collections.Generic;
using System.Text;
using ApiModel.Login;

namespace ApiModel._ResponseDTO
{
    public class CredencialesResponseDTO
    {
        public string CodigoUsuario { get; set; }
        //public string PasswordUsuario { get; set; }

        public CredencialesResponseDTO Mapper(CredencialesResponseDTO dto, CredencialesUsuaroBE obj)
        {
            dto.CodigoUsuario = obj.CodigoUsuario;
            //dto.PasswordUsuario = obj.PasswordUsuario;
            return dto;
        }
    }
}
