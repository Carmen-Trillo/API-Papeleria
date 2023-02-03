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
            //get para comprobar que el cantida pedido<=sctok, añadir el pedido y despés hacer un update que modifique el stock
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
                .Where(p => p.Id == id).First();

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
                                            .Where(p => p.IsActive == true);
                                            //.Where(p => p.Pagado == true)
                                            //.Where(p => p.Entregado == true);
                                            
            //.Where(p => p.Pagado == true);




            if (pedidoFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(p => p.FechaPedido > pedidoFilter.InsertDateFrom);
            }

            if (pedidoFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(p => p.FechaPedido < pedidoFilter.InsertDateTo);
            }
            if (pedidoFilter.ImporteTotalDesde != null)
            {
                resultList = resultList.Where(p => p.ImporteTotal > pedidoFilter.ImporteTotalDesde);
            }

            if (pedidoFilter.ImporteTotalHasta != null)
            {
                resultList = resultList.Where(p => p.ImporteTotal < pedidoFilter.ImporteTotalHasta);
            }

            if (pedidoFilter.FechaEntregaDesde != null)
            {
                resultList = resultList.Where(p => p.FechaEntrega > pedidoFilter.FechaEntregaDesde);
            }

            if (pedidoFilter.FechaEntregaHasta != null)
            {
                resultList = resultList.Where(p => p.FechaEntrega < pedidoFilter.FechaEntregaHasta);
            }

            return resultList.ToList();

        }

        private void Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public List<PedidoItem> GetPedidosByCliente(int idCliente)
        {
            var resultList = _serviceContext.Set<PedidoItem>()
                        .Where(p => p.IdCliente == idCliente);
            return resultList.ToList();
        }

        public List<PedidoItem> GetPedidosByProducto(int idProducto)
        {
            var resultList = _serviceContext.Set<PedidoItem>()
                        .Where(p => p.IdProducto == idProducto);
            return resultList.ToList();
        }

        public List<PedidoItem> GetPedidosByPagados(bool pagado)
        {
            var resultList = _serviceContext.Set<PedidoItem>()
                                            .Where(p => p.Pagado == true);
            var resultListNoPagados = _serviceContext.Set<PedidoItem>()
                                            .Where(p => p.Pagado == false);

            if (pagado == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoPagados.ToList();
            }
        }
        public List<PedidoItem> GetPedidosByEntregados(bool entregado)
        {
            var resultList = _serviceContext.Set<PedidoItem>()
                                            .Where(p => p.Entregado == true);
            var resultListNoEntregados = _serviceContext.Set<PedidoItem>()
                                            .Where(p => p.Entregado == false);

            if (entregado == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoEntregados.ToList();
            }
        }
    }
}