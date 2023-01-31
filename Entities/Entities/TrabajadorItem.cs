using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TrabajadorItem: PersonaItem
    {
        public TrabajadorItem() { }
        public int idUsuario { get; set; }
        public string Puesto { get; set; }
        public decimal Salario { get; set; }
        public int IdRol { get; set; }
        public bool IsActive { get; set; }

    }
}
