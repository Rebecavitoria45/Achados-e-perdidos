using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoController : ControllerBase
    {
        private readonly ObjetoService _objetoService;
        public ObjetoController(ObjetoService objetoService)
        {
            _objetoService = objetoService;
        }
        [HttpGet("/ListarObjetos")]
        public async Task<ActionResult<ResponseModel<List<Objeto>>>> ListaObjetos()
        {
            var objetos = await _objetoService.ListarObjetos();
            return Ok(objetos);
        }
        [HttpPost("/CriarObjeto")]
        public async Task<ActionResult<ResponseModel<Objeto>>> CriarObjeto(ObjetoDto objetoDto)
        {
            var objeto = await _objetoService.CriarObjeto(objetoDto);
            return Ok(objeto);
        }
        [HttpDelete("/DeletarObjeto/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> DeletarObjeto(int id)
        {
            var objeto = await  _objetoService.DeletarObjeto(id);
            return Ok(objeto);
        }
        [HttpPut("/AtualizarObjeto/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> AtualizarObjeto(int id, ObjetoDto objetoDto)
        {
            var objeto = await _objetoService.AtualizarObjeto(id, objetoDto);
            return Ok(objeto);
        }
        [HttpGet("/BuscarPorId/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> BuscarPorId(int id)
        {
            var objeto = await _objetoService.BuscarObjetoPorId(id);
            return Ok(objeto);
        }
    }
}
