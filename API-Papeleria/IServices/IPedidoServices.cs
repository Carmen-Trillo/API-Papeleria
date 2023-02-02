using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Papeleria.IServices
{
    public interface IPedidoServices
    {
        int InsertPedido(NewPedidoRequest newPedidoRequest);
        void UpdatePedido(PedidoItem pedidoItem);
        void DeletePedido(int id);
        List<PedidoItem> GetAllPedidos();
        List<PedidoItem> GetPedidosByCriteria(PedidoFilter pedidoFilter);


        /*List<PedidoItem> GetPedidosByCliente(int idClientes);
        List<PedidoItem> GetPedidosByProducto(int idProductos);
        List<PedidoItem> GetPedidosByPagado(PedidoFilter pedidoFilter);
        List<PedidoItem> GetPedidosByEntregado(PedidoFilter pedidoFilter);*/
    }
}
