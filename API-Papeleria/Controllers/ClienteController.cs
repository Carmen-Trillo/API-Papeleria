using API_Papeleria.IServices;
using API_Papeleria.Controllers;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using APIService.Controllers;

namespace API_Papeleria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IClienteServices _clienteServices;
        public ClienteController(ILogger<ProductoController> logger, IClienteServices clienteServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
        }

        [HttpPost(Name = "InsertUser")]
        public int Post([FromBody] ClienteItem clienteItem)
        {
            return _clienteServices.InsertCliente(clienteItem);
        }
    }
}
