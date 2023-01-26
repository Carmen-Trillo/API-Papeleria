using API_Papeleria.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoServices _productoService;
        public ProductoController(ILogger<ProductoController> logger, IProductoServices productoService)
        {
            _logger = logger;
            _productoService = productoService;
        }

        [HttpPost(Name = "InsertProducto")]
        public int Post([FromBody] ProductoItem productoItem)
        {
            //     _userService.ValidateCredentials(clienteItem);
            return _productoService.InsertProducto(productoItem);
        }

        [HttpGet(Name = "GetAllProductos")]
        public List<ProductoItem> GetAll()
        {
            //     _userService.ValidateCredentials(clienteItem);
            return _productoService.GetAllProductos();
        }

        [HttpGet(Name = "GetProductosByCriteria")]
        public List<ProductoItem> GetByCriteria(bool isActive)
        {
            var productoFilter = new ProductoFilter();
            productoFilter.IsActive = isActive;
            return _productoService.GetProductosByCriteria(productoFilter);
        }
    }
}
