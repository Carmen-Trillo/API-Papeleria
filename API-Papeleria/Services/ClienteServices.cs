using API_Papeleria.IServices;
using API_Papeleria.Services;
using Entities.Entities;
using Logic.ILogic;

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
            _clienteLogic.InsertClienteItem(clienteItem);
            return clienteItem.Id;
        }
    }
}
