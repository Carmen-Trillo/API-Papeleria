using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Papeleria.IServices
{
    public interface IUsuarioServices
    {
        int InsertUsuario(NewUsuarioRequest newUsuarioRequest);
        void UpdateUsuario(UsuarioItem usuarioItem);
        void DeleteUsuario(int id);
        List<UsuarioItem> GetAllUsuarios();
        List<UsuarioItem> GetUsuariosByCriteria(UsuarioFilter usuarioFilter);
    }
}
