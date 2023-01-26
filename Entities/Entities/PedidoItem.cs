using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }

        public int Cantidad { get; set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; private set; }
        public bool Entregado { get; private set; }
        public bool Pagado { get; private set; }
    }
}
