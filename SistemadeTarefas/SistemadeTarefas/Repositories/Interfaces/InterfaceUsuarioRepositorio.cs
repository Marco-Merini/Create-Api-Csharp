using SistemadeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemadeTarefas.Repositories.Interfaces
{
    public interface InterfaceUsuarioRepositorio
    {
        Task<List<UsuarioModel>> SearchAllUsers();
        Task<UsuarioModel> SearchId(int id);
        Task<UsuarioModel> Add(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
