using API_Papeleria.IServices;
using Entities.Entities;
using Logic.ILogic;

namespace API_Papeleria.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoLogic _pedidoLogic;
        public PedidoServices(IPedidoLogic pedidoLogic)
        {
            _pedidoLogic = pedidoLogic;
        }
        public int InsertPedido(PedidoItem pedidoItem)
        {
            _pedidoLogic.InsertPedidoItem(pedidoItem);
            return pedidoItem.Id;
        }
    }
}
