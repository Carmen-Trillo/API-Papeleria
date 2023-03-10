using API_Papeleria.IServices;
using API_Papeleria.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IProductoServices _productoServices;
        public ProductoController(ISecurityServices securityServices, IProductoServices productoServices)
        {
            _securityServices = securityServices;
            _productoServices = productoServices;
        }

        [HttpPost(Name = "InsertarProducto")]
        public int Post([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] ProductoItem productoItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.InsertProducto(productoItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerProductos")]
        public List<ProductoItem> GetAllProductos([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.GetAllProductos();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarProductosPorFiltro")]
        public List<ProductoItem> GetProductosByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] ProductoFilter productoFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.GetProductosByCriteria(productoFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
        [HttpGet(Name = "MostrarProductosPorMarca")]
        public List<ProductoItem> GetProductosByMarca([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] string marca)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _productoServices.GetProductosByMarca(marca);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarProducto")]
        public void Patch([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromBody] ProductoItem productoItem)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _productoServices.UpdateProducto(productoItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
            if (validCredentials == true)
            {
                _productoServices.DeleteProducto(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
        
    }

}
