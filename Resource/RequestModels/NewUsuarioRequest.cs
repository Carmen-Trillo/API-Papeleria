using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    public class NewUsuarioRequest
    {
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public UsuarioItem ToUsuarioItem()
        {
            var usuarioItem = new UsuarioItem();

            usuarioItem.IdPersona = IdPersona;
            usuarioItem.IdRol = IdRol;
            usuarioItem.Usuario = Usuario;
            usuarioItem.Password = Password;

            usuarioItem.InsertDate = DateTime.Now;
            usuarioItem.UpdateDate = DateTime.Now;
            usuarioItem.IsActive = true;

            return usuarioItem;
        }

  
    }
}
