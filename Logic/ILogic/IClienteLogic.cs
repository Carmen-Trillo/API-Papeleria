using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IClienteLogic
    {
        int InsertCliente(ClienteItem clienteItem);
        void UpdateCliente(ClienteItem clienteItem);
        void DeleteCliente(int id);
        List<ClienteItem> GetAllClientes();
        List<ClienteItem> GetClientesByCriteria(ClienteFilter clienteFilter);
    }
}
