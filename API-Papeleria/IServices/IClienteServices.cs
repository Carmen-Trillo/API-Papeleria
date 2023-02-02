using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Papeleria.IServices
{
    public interface IClienteServices
    {
        int InsertCliente(ClienteItem clienteItem);
        void UpdateCliente(ClienteItem clienteItem);
        void DeleteCliente(int id);
        List<ClienteItem> GetAllClientes();
        List<ClienteItem> GetClientesByCriteria(ClienteFilter clienteFilter);
    }
}
