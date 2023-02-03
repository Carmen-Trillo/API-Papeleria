using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    //ServiceContext _serviceContext;
    public class NewPedidoRequest
    {
        //public NewPedidoRequest(ServiceContext serviceContext) {
        //    _serviceContext = serviceContext;
        //}
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }

        public int IdProducto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; private set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }

        public PedidoItem ToPedidoItem()
        {
            var pedidoItem = new PedidoItem();

            pedidoItem.IdWeb = IdWeb;
            pedidoItem.FechaPedido = FechaPedido;
            pedidoItem.IdProducto = IdProducto;
            pedidoItem.IdCliente = IdCliente;
            pedidoItem.IdTipoCliente= IdTipoCliente;
            pedidoItem.Cantidad = Cantidad;
            pedidoItem.Precio= Precio;

            //pedidoItem.Descuento = 0.2M * (Cantidad * Precio);

            if (pedidoItem.IdTipoCliente == 1)
            {
                pedidoItem.Descuento = 0.1M* (Cantidad * Precio);
            }
            else if (pedidoItem.IdTipoCliente == 2)
            {
                pedidoItem.Descuento = 0.15M* (Cantidad * Precio);
            }
            else if (pedidoItem.IdTipoCliente == 3)
            {
                pedidoItem.Descuento = 0.2M * (Cantidad * Precio);
            }
            else
            {
                pedidoItem.Descuento = 0;
            }

            if (pedidoItem.IdTipoCliente == 1)
            {
                pedidoItem.ImporteTotal = 0.9M * (Cantidad * Precio);
            }
            else if (pedidoItem.IdTipoCliente == 2)
            {
                pedidoItem.ImporteTotal = 0.85M * (Cantidad * Precio);
            }
            else if (pedidoItem.IdTipoCliente == 3)
            {
                pedidoItem.ImporteTotal = 0.8M * (Cantidad * Precio);
            }
            else
            {
                pedidoItem.ImporteTotal = Cantidad*Precio;
            }
            //pedidoItem.ImporteTotal = (Cantidad * Precio) - pedidoItem.Descuento;
 
            pedidoItem.FechaEntrega = FechaEntrega;
            pedidoItem.Pagado = Pagado;
            pedidoItem.Entregado = Entregado;
            pedidoItem.IsActive = true;

            return pedidoItem;

            //buscas en base el producto y su precio.
        }
    }
}
