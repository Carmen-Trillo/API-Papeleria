using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PedidoLogic : BaseContextLogic, IPedidoLogic
    {
        public PedidoLogic(ServiceContext serviceContext) : base(serviceContext) { }
        public void InsertPedidoItem(PedidoItem pedidoItem)
        {
            _serviceContext.Pedidos.Add(pedidoItem);
            _serviceContext.SaveChanges();
        }
    }
}
