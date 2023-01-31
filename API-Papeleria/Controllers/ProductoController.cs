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

        [HttpPost(Name = "InsertProducto")]
        public int Post([FromBody] ProductoItem productoItem)
        {
            //     _userService.ValidateCredentials(usuarioItem);
            return _productoServices.InsertProducto(productoItem);
        }

        [HttpGet(Name = "GetAllProductos")]
        public List<ProductoItem> GetAll()
        {
            //     _userService.ValidateCredentials(usuarioItem);
            return _productoServices.GetAllProductos();
        }

        [HttpGet(Name = "GetProductosByCriteria")]
        public List<ProductoItem> GetByCriteria(bool isActive)
        {
            var productoFilter = new ProductoFilter();
            productoFilter.IsActive = isActive;
            return _productoServices.GetProductosByCriteria(productoFilter);
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
