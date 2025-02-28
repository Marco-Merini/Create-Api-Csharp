using SistemadeTarefas.Repositories.Interfaces;
using SistemadeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemadeTarefas.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemadeTarefas.Repositories
{
    public class UsuarioRepositorio : InterfaceUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        //SearchAllUsers
        public async Task<List<UsuarioModel>> SearchAllUsers()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        //SearchId
        public async Task<UsuarioModel> SearchId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Add
        public async Task<UsuarioModel> Add(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        //Update
        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioId = await SearchId(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            usuarioId.Name = usuario.Name;
            usuarioId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioId);
            await _dbContext.SaveChangesAsync();

            return usuarioId;
        }

        //Delete
        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioId = await SearchId(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
