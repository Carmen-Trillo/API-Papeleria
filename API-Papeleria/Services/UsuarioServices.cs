using API_Papeleria.IServices;
using API_Papeleria.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Papeleria.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioLogic _usuarioLogic;
        public UsuarioServices(IUsuarioLogic usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
        }
        public int InsertUsuario(NewUsuarioRequest newUsuarioRequest)
        {
            var newUsuarioItem = newUsuarioRequest.ToUsuarioItem();
            return _usuarioLogic.InsertUsuario(newUsuarioItem);
        }
        public List<UsuarioItem> GetAllUsuarios()
        {
            return _usuarioLogic.GetAllUsuarios();
        }
        public List<UsuarioItem> GetUsuariosByCriteria(UsuarioFilter usuarioFilter)
        {
            return _usuarioLogic.GetUsuariosByCriteria(usuarioFilter);
        }

        public void UpdateUsuario(UsuarioItem usuarioItem)
        {
            _usuarioLogic.UpdateUsuario(usuarioItem);
        }

        public void DeleteUsuario(int id)
        {
            _usuarioLogic.DeleteUsuario(id);
        }
    }
}
