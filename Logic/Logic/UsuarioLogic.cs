using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly ServiceContext _serviceContext;
        public UsuarioLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertUsuario(UsuarioItem usuarioItem)
        {
            if (usuarioItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            _serviceContext.Usuarios.Add(usuarioItem);
            _serviceContext.SaveChanges();
            return usuarioItem.Id;
        }

        public void UpdateUsuario(UsuarioItem usuarioItem)
        {
            _serviceContext.Usuarios.Update(usuarioItem);

            _serviceContext.SaveChanges();
        }
        public void DeleteUsuario(int id)
        {
            var userToDelete = _serviceContext.Set<UsuarioItem>()
                 .Where(u => u.Id == id).First();

            userToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<UsuarioItem> GetAllUsuarios()
        {
            return _serviceContext.Set<UsuarioItem>().ToList();
        }
        public List<UsuarioItem> GetUsuariosByCriteria(UsuarioFilter usuarioFilter)
        {
            var resultList = _serviceContext.Set<UsuarioItem>()
                  .Where(u => u.IsActive == true);

            if (usuarioFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > usuarioFilter.InsertDateFrom);
            }

            if (usuarioFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < usuarioFilter.InsertDateTo);
            }

            return resultList.ToList();
        }

        
    }
}
