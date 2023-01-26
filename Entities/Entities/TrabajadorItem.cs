using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TrabajadorItem: UsuarioItem
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int IdRol { get; set; }

    }
}
