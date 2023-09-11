using ApiUsers.Data.Business;
using ApiUsers.Data.Dtos;
using ApiUsers.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosController() { 
        }

        [HttpGet]
        public IActionResult Get()
        {
            UsuariosBusiness business= new UsuariosBusiness();
            return Ok(business.GetAll());
        }

        [HttpGet("GetUsuario/{IdUsuario}")]
        public IActionResult GetUsuario(int IdUsuario)
        {
            UsuariosBusiness business = new UsuariosBusiness();
            return Ok(business.GetUsuario(IdUsuario));
        }

        [HttpPost]
        public IActionResult Post(UsuarioDto request)
        {
            UsuariosBusiness business = new UsuariosBusiness();
            GeneralResponse<Object> response = business.PostUsuario(request);
            return StatusCode(response.Code,response);
        }

        [HttpDelete("{IdUsuario}")]
        public IActionResult Delete(int IdUsuario)
        {
            UsuariosBusiness business = new UsuariosBusiness();
            GeneralResponse<Object> response = business.DeleteUsuario(IdUsuario);
            return StatusCode(response.Code, response);
        }
    }
}
