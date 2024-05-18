using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private  UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>>ListaUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }
        
        [HttpPost("/CadastrarUsuario")]
        public async Task<ActionResult<ResponseModel<Usuario>>> CriarUsuario(UsuarioDto usuarioDto)
        {
            var Usuario = await _usuarioService.CriarUsuario(usuarioDto);
            return Ok(Usuario);
        }
        [HttpDelete("/DeletarUsuario/{id}")]
        public async Task<ActionResult<ResponseModel<Usuario>>> DeletarUsuario(int id)
        {
            var deletar = await _usuarioService.DeletarUsuario(id);
            return Ok(deletar);
        }

        [HttpPut("/AtualizarUsuario/{id}")]
        public async Task<ActionResult<ResponseModel<Usuario>>> AtualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var atualizar = await _usuarioService.AtualizarUsuario(id, usuarioDto);
            return Ok(atualizar);
        }
    }
}
