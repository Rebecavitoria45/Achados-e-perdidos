using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _documentoService;
        public DocumentoController(DocumentoService documentoService)
        {
            _documentoService = documentoService;
        }
        /// <summary>
        /// Lista todos Documentos
        ///</summary>
        /// <response code="200">Retorna uma lista de Documentos.</response>
        [HttpGet("/api/documentos")]
        public async Task<ActionResult<ResponseModel<List<Documento>>>> ListarDocumentos()
        {
            var documentos = await _documentoService.ListarDocumentos();
            return Ok(documentos);
        }
        /// <summary>
        /// Busca documento pelo id
        ///</summary>
        /// <response code="200">Retorna o documento do id correspondente.</response>
        [HttpGet("/api/documentos/{id}")]
        public async Task<ActionResult<ResponseModel<Documento>>> BuscarDocumentoPorId(int id)
        {
            var documento = await _documentoService.BuscarDocumentoPorId(id);
            return Ok(documento);

        }
        /// <summary>
        ///Cadastra documento
        ///</summary>
        /// <response code="200">Retorna  documento cadastrado.</response>
        [HttpPost("/api/documentos")]
        public async Task<ActionResult<ResponseModel<Documento>>> CriarDocumento(DocumentoDto documentoDto)
        {
            var documento = await _documentoService.CriarDocumento(documentoDto);
            return Ok(documento);
        }
        /// <summary>
        /// Deleta documento pelo id
        ///</summary>
        /// <response code="200">Retorna mensagem de sucesso caso documento seja deletado.</response>
        [HttpDelete("/api/documentos/{id}")]
        public async Task<ActionResult<ResponseModel<Documento>>> DeletarDocumento(int id)
        {
            var documento = await _documentoService.DeletarDocumento(id);
            return Ok(documento);

        }
        /// <summary>
        /// Edita documento inteiro
        ///</summary>
        /// <response code="200">Retorna o documento atualizado.</response>
        [HttpPut("/api/documentos/{id}")]
        public async Task<ActionResult<ResponseModel<Documento>>> AtualizarDocumento(int id, DocumentoDto documentoDto)
        {
            var documento = await _documentoService.AtualizarDocumento(id, documentoDto);
            return Ok(documento);
        }
        /// <summary>
        /// Busca documentos pelo id do usuario 
        ///</summary>
        /// <response code="200">Retorna uma lista de documentos pelo id do usuário que cadastrou.</response>
        [HttpGet("/api/usuarios/documentos/{idusuario}")]
        public async Task<ActionResult<ResponseModel<List<Documento>>>> BuscarDocumentoPorUsuario(int idusuario)
        {
            var documentos = await _documentoService.BuscarDocumentosPorUsuario(idusuario);
            return Ok(documentos);
        }

       
    }
}
