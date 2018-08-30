using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientes.API.Business;
using clientes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private ClienteService _service;
        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _service.ListarTodos();
        }

        [HttpPost]
        public Resultado Post([FromBody]Cliente cliente)
        {
            return _service.Incluir(cliente);
        }
    }
}