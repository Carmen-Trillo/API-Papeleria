using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TipoClienteItem
    {
        public TipoClienteItem() { }
        public int Id { get; set; }
        public string TipoRol { get; set; }
        public bool IsActive { get; set; }
    }
}
