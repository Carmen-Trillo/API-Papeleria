using API_Papeleria.Controllers;
using API_Papeleria.IServices;
using API_Papeleria.Services;
using APIService.Controllers;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;

namespace API_Papeleria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IPedidoServices _pedidoServices;
        public PedidoController(ISecurityServices securityServices, IPedidoServices pedidoServices)
        {
            _securityServices = securityServices;
            _pedidoServices = pedidoServices;
        }

        [HttpPost(Name = "InsertarPedido")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] NewPedidoRequest newPedidoRequest)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.InsertPedido(newPedidoRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerPedidos")]
        public List<PedidoItem> GetAllPedidos([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetAllPedidos();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorFiltro")]
        public List<PedidoItem> GetPedidosByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] PedidoFilter pedidoFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByCriteria(pedidoFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name ="MostrarPedidosPorCliente")]
        public List<PedidoItem> GetPedidosByCliente([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int idCliente)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByCliente(idCliente);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductos")]
        public List<PedidoItem> GetPedidosByProducto([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int idProducto)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByProducto(idProducto);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductosPagados")]
        public List<PedidoItem> GetPedidosByPagados([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] bool pagado)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByPagados(pagado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarPedidosPorProductosEntregados")]
        public List<PedidoItem> GetPedidosByEntregados([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] bool entregado)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _pedidoServices.GetPedidosByEntregados(entregado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarPedido")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] PedidoItem pedidoItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _pedidoServices.UpdatePedido(pedidoItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarPedido")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _pedidoServices.DeletePedido(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        
    }
}
