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
        /// <summary>
        /// Lista todos Objetos
        ///</summary>
        /// <response code="200">Retorna uma lista de objetos.</response>
        [HttpGet("/Objetos")]
        public async Task<ActionResult<ResponseModel<List<Objeto>>>> ListaObjetos()
        {
            var objetos = await _objetoService.ListarObjetos();
            return Ok(objetos);
        }
        /// <summary>
        /// Cadastra Objeto
        ///</summary>
        /// <response code="200">Retorna objeto cadastrado.</response>
        [HttpPost("/Objetos")]
        public async Task<ActionResult<ResponseModel<Objeto>>> CriarObjeto(ObjetoDto objetoDto)
        {
            var objeto = await _objetoService.CriarObjeto(objetoDto);
            return Ok(objeto);
        }
        /// <summary>
        /// Deleta objeto pelo id
        ///</summary>
        /// <response code="200">Retorna mensagem de sucesso caso objeto seja deletado.</response>
        [HttpDelete("/Objetos/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> DeletarObjeto(int id)
        {
            var objeto = await  _objetoService.DeletarObjeto(id);
            return Ok(objeto);
        }
        /// <summary>
        /// Atualiza objeto
        ///</summary>
        /// <response code="200">Retorna objeto atualizado.</response>
        [HttpPut("/Objetos/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> AtualizarObjeto(int id, ObjetoDto objetoDto)
        {
            var objeto = await _objetoService.AtualizarObjeto(id, objetoDto);
            return Ok(objeto);
        }
        /// <summary>
        /// Busca objeto pelo id
        ///</summary>
        /// <response code="200">Retorna o objeto do id correspondente.</response>
        [HttpGet("/Objetos/{id}")]
        public async Task<ActionResult<ResponseModel<Objeto>>> BuscarPorId(int id)
        {
            var objeto = await _objetoService.BuscarObjetoPorId(id);
            return Ok(objeto);
        }
    }
}
