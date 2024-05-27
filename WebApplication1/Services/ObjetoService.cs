using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Database;
using WebApplication1.Dtos;
using WebApplication1.Enuns;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ObjetoService
    {
        private readonly Context _context;
        public ObjetoService(Context context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Objeto>>> ListarObjetos()
        {
            ResponseModel<List<Objeto>> resposta = new ResponseModel<List<Objeto>>();
            try
            {
               var objetos = await _context.Objetos.ToListAsync();
                if(objetos.IsNullOrEmpty())
                {
                    resposta.Mensagem = "Nenhum Objeto encontrado";
                    return resposta;
                }
                resposta.Dados = objetos;   
                return resposta;
            }catch (Exception ex)
            {
              resposta.Mensagem= ex.Message;
                resposta.Status = false;
                return resposta;    
            }
        }
        public async Task<ResponseModel<Objeto>> CriarObjeto(ObjetoDto objetoDto)
        {
            ResponseModel<Objeto> resposta = new ResponseModel<Objeto>();
            try
            {
                var objeto = new Objeto()
                {
                    Nome = objetoDto.Nome,
                    FotoObjeto = objetoDto.FotoObjeto,
                    Ativo = objetoDto.Ativo,
                    Descrição = objetoDto.Descrição,
                    Categoria = objetoDto.Categoria,
                    UsuarioId = objetoDto.UsuarioId,
                };
                if (Enum.IsDefined(typeof(CategoriaEnum), objeto.Categoria))
                {
                    _context.Objetos.Add(objeto);
                    await _context.SaveChangesAsync();
                    resposta.Dados = objeto;
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Categoria não existe";
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
        public async Task<ResponseModel<Objeto>> DeletarObjeto (int Id)
        {
            ResponseModel<Objeto> resposta = new ResponseModel<Objeto>();
            try
            {
                var Objeto = await  _context.Objetos.FirstOrDefaultAsync (Objeto => Objeto.IdObjeto == Id);
                if(Objeto == null)
                {
                    resposta.Mensagem = "Nenhum Objeto encontrado com esse id";
                    
                    return resposta;
                }
                 _context.Objetos.Remove(Objeto);  
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Objeto removido com sucesso";
                return resposta;
               
             }catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Objeto>> AtualizarObjeto (int Id, ObjetoDto ObjetoDto)
        {
            ResponseModel<Objeto> resposta = new ResponseModel<Objeto>(); 
            try 
            {
                var objeto = await _context.Objetos.FirstOrDefaultAsync(objeto => objeto.IdObjeto == Id);
                if (objeto == null)
                {
                    resposta.Mensagem = "Objeto não encontrado";
                    return resposta;
                }
                objeto.Nome = ObjetoDto.Nome;
                objeto.FotoObjeto = ObjetoDto.FotoObjeto;
                objeto.Ativo = ObjetoDto.Ativo;
                objeto.Descrição = ObjetoDto.Descrição;
                objeto.Categoria = ObjetoDto.Categoria;
                objeto.UsuarioId = ObjetoDto.UsuarioId;
                if (Enum.IsDefined(typeof(CategoriaEnum), objeto.Categoria))
                {
                    _context.Objetos.Update(objeto);
                    await _context.SaveChangesAsync();
                    resposta.Dados = objeto;
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Categoria não existe";
                    resposta.Status = false;
                    return resposta;
                }


            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Objeto>> BuscarObjetoPorId (int Id)
        {
            ResponseModel<Objeto> resposta = new ResponseModel<Objeto> ();
            try
            {
                var objeto = await _context.Objetos.FirstOrDefaultAsync(objeto => objeto.IdObjeto == Id);
                if (objeto == null)
                {
                    resposta.Mensagem = "Objeto não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = objeto;
                return resposta;   
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
