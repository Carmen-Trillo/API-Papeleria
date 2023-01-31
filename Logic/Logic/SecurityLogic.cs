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
    public class SecurityLogic : ISecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public SecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public bool ValidateUsuarioCredentials(string usuarioUsuario, string usuarioPassWord, int idRolItem)
        {
            var selectedUsuario = _serviceContext.Set<UsuarioItem>()
                                .Where(u => u.Usuario == usuarioUsuario
                                    && u.Password == usuarioPassWord
                                    && u.IdRol == idRolItem).FirstOrDefault();

            if (selectedUsuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
