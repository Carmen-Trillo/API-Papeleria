using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        public int Cantidad { get; set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; private set; }
        public bool Pagado { get; private set; }
        public bool Entregado { get; private set; }
        public bool IsActive { get; set; }
    }
}
