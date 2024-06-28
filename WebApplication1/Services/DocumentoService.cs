using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Database;
using WebApplication1.Dtos;
using WebApplication1.Enuns;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DocumentoService
    {
        private readonly Context _context;
        public DocumentoService(Context context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Documento>>> ListarDocumentos()
        {
            ResponseModel<List<Documento>> resposta = new ResponseModel<List<Documento>>();
            try
            {
                var documentos = await _context.Documentos
                    .Include(u => u.Usuario)
                    .ToListAsync();
                if (documentos.IsNullOrEmpty())
                {
                    resposta.Mensagem = "Nenhum documento cadastrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = documentos;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
        public async Task<ResponseModel<Documento>> BuscarDocumentoPorId(int id)
        {
            ResponseModel<Documento> resposta = new ResponseModel<Documento>();
            try
            {
                var documento = await _context.Documentos.FirstOrDefaultAsync(documento => documento.IdDocumento == id);
                if (documento == null)
                {
                    resposta.Mensagem = "Nenhum documento encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = documento;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
        public async Task<ResponseModel<Documento>> CriarDocumento(DocumentoDto documentoDto)
        {
            ResponseModel<Documento> resposta = new ResponseModel<Documento>();
            try
            {
                var documento = new Documento
                {
                    TipoDocumento = documentoDto.TipoDocumento,
                    NumeroDocumento = documentoDto.NumeroDocumento,
                    NomeCompletoDocumento = documentoDto.NomeCompletoDocumento,
                    EstadoDocumento = documentoDto.EstadoDocumento,
                    UsuarioId = documentoDto.UsuarioId,
                };
                if (Enum.IsDefined(typeof(EstadoEnum), documento.EstadoDocumento))
                {
                    _context.Documentos.Add(documento);
                    await _context.SaveChangesAsync();
                    resposta.Dados = documento;
                    return resposta;
                }
                resposta.Mensagem = "Indice de estado não existente";
                resposta.Status = false;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Documento>> DeletarDocumento(int Id)
        {
            ResponseModel<Documento> resposta = new ResponseModel<Documento>();
            try
            {
                var documento = await _context.Documentos.FirstOrDefaultAsync(documento => documento.IdDocumento == Id);
                if (documento == null)
                {
                    resposta.Mensagem = "Documento não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Documentos.Remove(documento);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Documento Removido com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Documento>> AtualizarDocumento(int Id, DocumentoDto DocumentoDto)
        {
            ResponseModel<Documento> resposta = new ResponseModel<Documento>();
            try
            {
                var documento = await _context.Documentos.FirstOrDefaultAsync(documento => documento.IdDocumento== Id);
                if (documento == null)
                {
                    resposta.Mensagem = "Documento não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                documento.TipoDocumento = DocumentoDto.TipoDocumento;
                documento.NumeroDocumento = DocumentoDto.NumeroDocumento;
                documento.NomeCompletoDocumento = DocumentoDto.NomeCompletoDocumento;
                documento.EstadoDocumento = DocumentoDto.EstadoDocumento;
                documento.UsuarioId = DocumentoDto.UsuarioId;
                if (Enum.IsDefined(typeof(EstadoEnum), documento.EstadoDocumento))
                {
                    _context.Documentos.Update(documento);
                    await _context.SaveChangesAsync();
                    resposta.Dados = documento;
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Indice de estado não existente";
                    resposta.Status = false;
                    return resposta;
                }


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<Documento>>>BuscarDocumentosPorUsuario (int idusuario)
        {
            ResponseModel<List<Documento>> resposta = new ResponseModel<List<Documento>>();
            try
            {
                var documentos = await _context.Documentos
                  //.Include(u => u.Usuario)
                    .Where(documento => documento.Usuario.IdUsuario == idusuario)
                    .ToListAsync();
               if(documentos.IsNullOrEmpty()) 
                {
                    resposta.Mensagem = "Nenhum documento cadastrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados= documentos;
                return resposta;
            }catch (Exception ex) 
            {
                resposta.Mensagem= ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
       
    }
}
