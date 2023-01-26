using API_Papeleria.Controllers;
using API_Papeleria.IServices;
using APIService.Controllers;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Papeleria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IPedidoServices _pedidoService;
        public PedidoController(ILogger<ProductoController> logger, IPedidoServices pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        [HttpPost(Name = "InsertPedido")]
        public int Post([FromBody] PedidoItem pedidoItem)
        {
            return _pedidoService.InsertPedido(pedidoItem);
        }
    }
}
