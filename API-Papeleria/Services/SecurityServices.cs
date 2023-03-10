using API_Papeleria.IServices;
using Data;
using Entities.Entities;
using Logic.ILogic;

namespace API_Papeleria.Services
{
    public class SecurityServices : ISecurityServices
    {
        private readonly ISecurityLogic _securityLogic;

        public SecurityServices(ISecurityLogic securityLogic)
        {
            _securityLogic = securityLogic;
        }
        public bool ValidateUsuarioCredentials(string usuarioUsuario, string usuarioPassWord, int idRol)
        {

            return _securityLogic.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassWord, idRol);
        }
    }
}
