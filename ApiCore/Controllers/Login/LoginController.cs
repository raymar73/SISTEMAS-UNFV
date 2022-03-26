using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBussinessLogic.Interfaces.Login;
using ApiModel.Login;
using ApiModel._ResponseDTO;

namespace ApiCore.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICredencialesLogic _credenciales;
        public ResponseDTO _ResponseDTO;
        public LoginController(ICredencialesLogic credenciales)
        {
            _credenciales = credenciales;
        }
        [HttpPost("login")]
        public IActionResult LoguearUsuario([FromBody] CredencialesUsuaroBE usuario)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                var obj = _credenciales.LoguearUsuario(usuario);
                return Ok(_ResponseDTO.Success(_ResponseDTO, obj));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
