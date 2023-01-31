using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PedidoLogic : IPedidoLogic
    {
        private readonly ServiceContext _serviceContext;
        public PedidoLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertPedido(PedidoItem pedidoItem)
        {
            _serviceContext.Pedidos.Add(pedidoItem);
            _serviceContext.SaveChanges();
            return pedidoItem.Id;
        }

        public void UpdatePedido(PedidoItem pedidoItem)
        {
            _serviceContext.Pedidos.Update(pedidoItem);

            _serviceContext.SaveChanges();
        }

        public void DeletePedido(int id)
        {
            var pedidoToDelete = _serviceContext.Set<PedidoItem>()
                .Where(u => u.Id == id).First();

            pedidoToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<PedidoItem> GetAllPedidos()
        {
            return _serviceContext.Set<PedidoItem>().ToList();
        }

        public List<PedidoItem> GetPedidosByCriteria(PedidoFilter pedidoFilter)
        {
            var resultList = _serviceContext.Set<PedidoItem>()
                                        .Where(u => u.IsActive == true);

            //.Where(u => u.Marca = productoFilter.Marca);

            if (pedidoFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.FechaPedido > pedidoFilter.InsertDateFrom);
            }

            if (pedidoFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.FechaPedido < pedidoFilter.InsertDateTo);
            }
            if (pedidoFilter.ImporteTotalDesde != null)
            {
                resultList = resultList.Where(u => u.ImporteTotal > pedidoFilter.ImporteTotalDesde);
            }

            if (pedidoFilter.ImporteTotalHasta != null)
            {
                resultList = resultList.Where(u => u.ImporteTotal < pedidoFilter.ImporteTotalHasta);
            }

            return resultList.ToList();
        }
        /*public List<PedidoItem> GetPedidosByCliente(int IdCliente)
        {
            return _serviceContext.Set<PedidoItem>()
                .Where(u => u.IdCliente == IdCliente).First();
                .ToList();
        }
        public List<PedidoItem> GetPedidosByProducto(int idClientes)
        {

        }
        public List<PedidoItem> GetPedidosByPagado(PedidoFilter pedidoFilter)
        {

        }
        public List<PedidoItem> GetPedidosByEntregado(PedidoFilter pedidoFilter)
        {

        }*/
    }
}

//public int? IdCliente { get; set; }
//public int? IdProducto { get; set; }
//public DateTime? FechaEntrega { get; private set; }
//public bool Pagado { get; private set; }
//public bool Entregado { get; private set; }