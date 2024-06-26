﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
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
       
        /// <summary>
        /// Lista todos Usuários
        ///</summary>
        /// <response code="200">Retorna uma lista de usuários.</response>
        [HttpGet("/api/usuarios")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>>ListaUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }
        /// <summary>
        /// Cadastra Usuário
        ///</summary>
        /// <response code="200">Retorna o Usuário que foi cadastrado</response>
        [HttpPost("/api/usuarios")]
        public async Task<ActionResult<ResponseModel<Usuario>>> CriarUsuario(UsuarioDto usuarioDto)
        {
            var Usuario = await _usuarioService.CriarUsuario(usuarioDto);
            return Ok(Usuario);
        }
        /// <summary>
        /// Deleta usuário pelo id
        ///</summary>
        /// <response code="200">Retorna mensagem de sucesso caso usuário seja deletado.</response>
        [HttpDelete("/api/usuarios/{id}")]
        public async Task<ActionResult<ResponseModel<Usuario>>> DeletarUsuario(int id)
        {
            var deletar = await _usuarioService.DeletarUsuario(id);
            return Ok(deletar);
        }
        /// <summary>
        /// Edita Usuário inteiro
        ///</summary>
        /// <response code="200">Retorna o usuário atualizado.</response>
        [HttpPut("/api/usuarios/{id}")]
        public async Task<ActionResult<ResponseModel<Usuario>>> AtualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var atualizar = await _usuarioService.AtualizarUsuario(id, usuarioDto);
            return Ok(atualizar);
        }
        /// <summary>
        /// Busca usuário pelo id
        ///</summary>
        /// <response code="200">Retorna usuário do id correspondente.</response>
        [HttpGet("/api/usuarios/{id}")]
        public async Task<ActionResult<ResponseModel<Usuario>>>BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);
            return Ok(usuario); 
        }

       
        [HttpPost("/api/usuarios/login")]
        public async Task<ActionResult>FazerLogin(LoginDto loginDto)
        {
            var usuario = await _usuarioService.LoginUsuario(loginDto) ;
            if(usuario == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }
            return Ok(new { usuarioId = usuario.IdUsuario });
        }

    }

}

