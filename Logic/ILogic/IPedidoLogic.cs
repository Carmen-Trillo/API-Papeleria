using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPedidoLogic
    {
        int InsertPedido(PedidoItem pedidoItem);
        void UpdatePedido(PedidoItem pedidoItem);
        void DeletePedido(int id);
        List<PedidoItem> GetAllPedidos();
        List<PedidoItem> GetPedidosByCriteria(PedidoFilter pedidoFilter);
        List<PedidoItem> GetPedidosByCliente(int idCliente);
        List<PedidoItem> GetPedidosByProducto(int idProducto);

        List<PedidoItem> GetPedidosByPagados(bool pagado);
        List<PedidoItem> GetPedidosByEntregados(bool entregado);
    }
}
