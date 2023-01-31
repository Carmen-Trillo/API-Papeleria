using API_Papeleria.IServices;
using API_Papeleria.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Papeleria.Services
{
    public class TipoClienteServices : ITipoClienteServices
    {
        private readonly ITipoClienteLogic _tipoClienteLogic;
        public TipoClienteServices (ITipoClienteLogic tipoClienteLogic)
        {
            _tipoClienteLogic = tipoClienteLogic;
        }

        public void DeleteTipoCliente(int id)
        {
            _tipoClienteLogic.DeleteTipoCliente(id);
        }

        public List<TipoClienteItem> GetAllTiposClientes()
        {
            return _tipoClienteLogic.GetAllTiposClientes();
        }

        public int InsertTipoCliente(TipoClienteItem tipoClienteItem)
        {
            _tipoClienteLogic.InsertTipoCliente(tipoClienteItem);
            return tipoClienteItem.Id;
        }

        public void UpdateTipoCliente(TipoClienteItem tipoClienteItem)
        {
            _tipoClienteLogic.UpdateTipoCliente(tipoClienteItem);
        }

    }
}
