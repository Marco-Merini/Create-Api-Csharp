using Microsoft.AspNetCore.Mvc;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemadeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly InterfaceUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(InterfaceUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> SearchAllUsers()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.SearchAllUsers();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> SearchId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.SearchId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Register([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Add(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deleted = await _usuarioRepositorio.Delete(id);
            return Ok(deleted);
        }
    }
}