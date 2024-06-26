﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Database;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UsuarioService
    {
        private readonly Context _context;
        public UsuarioService(Context context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Usuario>>> ListarUsuarios()
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                if (usuarios.IsNullOrEmpty())
                {
                    resposta.Mensagem = "Nenhum usuário cadastrado";
                    resposta.Status =false;
                    return resposta;
                }
                resposta.Dados = usuarios;
                return resposta;
            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Usuario>> CriarUsuario(UsuarioDto UsuarioDto)
        {
            ResponseModel<Usuario> resposta = new ResponseModel<Usuario>();
            try
            {
                Usuario usuario = new Usuario
                {
                    Nome = UsuarioDto.Nome,
                    Email = UsuarioDto.Email,
                    Telefone = UsuarioDto.Telefone,
                    Senha = UsuarioDto.Senha,
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Usuário cadastrado";
                resposta.Dados = usuario;
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<Usuario>>DeletarUsuario(int Id)
          {
          ResponseModel<Usuario> resposta = new ResponseModel<Usuario>();
            try
            {
                var usuario = await  _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.IdUsuario == Id);
                 if(usuario == null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Usuário Removido com sucesso";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
          }
        public async Task<ResponseModel<Usuario>>AtualizarUsuario(int Id, UsuarioDto usuarioDto)
        {
            ResponseModel<Usuario> resposta = new ResponseModel<Usuario>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.IdUsuario == Id);
                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuário encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                usuario.Nome = usuarioDto.Nome;
                usuario.Email = usuarioDto.Email;
                usuario.Telefone = usuarioDto.Telefone;
                usuario.Senha = usuarioDto.Senha;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Usuário atualizado com sucesso";
                resposta.Dados = usuario;
                return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
       }
        public async Task<ResponseModel<Usuario>>BuscarUsuarioPorId(int Id)
        {
            ResponseModel<Usuario> resposta = new ResponseModel<Usuario>();
            try
            {
              var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario=> usuario.IdUsuario== Id);
              if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    resposta.Status= false;
                    return resposta;
                }
              resposta.Dados= usuario;
              return resposta;
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
       
        public async Task<Usuario> LoginUsuario(LoginDto loginDto)
        {
            var usuario = await  _context.Usuarios.Where(x=> x.Email.Equals(loginDto.Email) && x.Senha.Equals(loginDto.Senha)).FirstOrDefaultAsync();
            if(usuario == null)
            {
                return null;
            }
            return usuario;
        }
        
        
        
        
        
        
        
        
      

    }
}
