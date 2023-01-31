using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClienteItem: PersonaItem
    {
        public ClienteItem() { }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public int IdTipoCliente { get; set; }
        public string Empresa { get; set; }
        public string Sector { get; set; }
        public bool IsActive { get; set; }

    }
}
