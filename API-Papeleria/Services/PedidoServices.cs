using API_Papeleria.IServices;
using API_Papeleria.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Resource.RequestModels;

namespace API_Papeleria.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoLogic _pedidoLogic;
        public PedidoServices(IPedidoLogic pedidoLogic)
        {
            _pedidoLogic = pedidoLogic;
        }

        public void DeletePedido(int id)
        {
            _pedidoLogic.DeletePedido(id);
        }

        public List<PedidoItem> GetAllPedidos()
        {
            return _pedidoLogic.GetAllPedidos();
        }

        public List<PedidoItem> GetPedidosByCriteria(PedidoFilter pedidoFilter)
        {
            return _pedidoLogic.GetPedidosByCriteria(pedidoFilter);
        }

        
        public int InsertPedido(NewPedidoRequest newPedidoRequest)
        {

            var newPedidoItem = newPedidoRequest.ToPedidoItem();
            return _pedidoLogic.InsertPedido(newPedidoItem);
        }

        public void UpdatePedido(PedidoItem pedidoItem)
        {
            _pedidoLogic.UpdatePedido(pedidoItem);
        }
    }
}
