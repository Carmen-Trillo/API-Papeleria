using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ITipoClienteLogic
    {
        int InsertTipoCliente(TipoClienteItem tipoClienteItem);
        void UpdateTipoCliente(TipoClienteItem tipoClienteItem);
        void DeleteTipoCliente(int id);
        List<TipoClienteItem> GetAllTiposClientes();
    }
}
