using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IUsuarioLogic
    {
        int InsertUsuario(UsuarioItem usuarioItem);
        void UpdateUsuario(UsuarioItem usuarioItem);
        void DeleteUsuario(int id);
        List<UsuarioItem> GetAllUsuarios();
        List<UsuarioItem> GetUsuariosByCriteria(UsuarioFilter usuarioFilter);
    }
}
