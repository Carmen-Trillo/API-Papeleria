using API_Papeleria.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;

namespace API_Papeleria.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteLogic _clienteLogic;
        public ClienteServices(IClienteLogic clienteLogic)
        {
            _clienteLogic = clienteLogic;
        }
        public int InsertCliente(ClienteItem clienteItem)
        {
            _clienteLogic.InsertCliente(clienteItem);
            return clienteItem.Id;
        }
        public List<ClienteItem> GetAllClientes()
        {
            return _clienteLogic.GetAllClientes();
        }
        public List<ClienteItem> GetClientesByCriteria(ClienteFilter clienteFilter)
        {
            return _clienteLogic.GetClientesByCriteria(clienteFilter);
        }

        public void UpdateCliente(ClienteItem clienteItem)
        {
            _clienteLogic.UpdateCliente(clienteItem);
        }

        public void DeleteCliente(int id)
        {
            _clienteLogic.DeleteCliente(id);
        }
    }
}
