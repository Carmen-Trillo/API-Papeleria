using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClienteItem:UsuarioItem
    {
        public ClienteItem() 
        {
            IsActive = true;
        }
        public string Usuario { get; set; }
        private string Password { get; set; }
        public string Email { get; set; } 
        public bool Socio { get; set; }
        public bool IsActive { get; private set; }
        public int IdRol { get; set; }
        public int IdRolItem { get; set; }
        
    }
}
