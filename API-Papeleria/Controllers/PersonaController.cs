using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Papeleria.IServices;
using System.Security.Authentication;

namespace API_Papeleria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonaController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IPersonaServices _personaServices;
        public PersonaController(ISecurityServices securityServices, IPersonaServices personaServices)
        {
            _securityServices = securityServices;
            _personaServices = personaServices;
        }

        [HttpPost(Name = "InsertarPersona")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] PersonaItem personaItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.InsertPersona(personaItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPersonas")]
        public List<PersonaItem> GetAllPersonas([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.GetAllPersonas();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPersona")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] PersonaItem personaItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _personaServices.UpdatePersona(personaItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPersona")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _personaServices.DeletePersona(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        /*[HttpGet(Name = "MostrarPersonaPorFiltro")]
        public List<PersonaItem> GetByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] PersonaFilter personaFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.GetPersonasByCriteria(personaFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }*/
    }
}
