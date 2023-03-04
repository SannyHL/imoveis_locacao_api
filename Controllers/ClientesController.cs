using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveis.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClientesController : Controller
    {
        private readonly IClientesRepository repository;

        public ClientesController(IClientesRepository repository)
        {
            this.repository = repository;
        }

        [HttpPut("/atualiza-cliente/{id}")]
        public IActionResult atualizarCliente(ClientesModel clientes, int id)
        {
            ClientesModel clienteModel = repository.atualizarCliente(clientes, id);
            return Ok(clientes);
        }

        [HttpGet("/{id}")]
        public IActionResult buscarClientePorId(int id)
        {
            ClientesModel cliente = repository.buscarClientePorId(id);
            return Ok(cliente);
        }


        [HttpGet]
        public IActionResult buscarTodosCliente()
        {
            List<ClientesModel> clientes = repository.buscarTodosCliente();
            return Ok(clientes);

        }

        [HttpPost]
        public IActionResult criarCliente([FromBody] ClientesModel clientes)
        {
            ClientesModel cliente = repository.criarCliente(clientes);
            return Ok(cliente);
        }

        [HttpDelete("/{id}")]
        public IActionResult deleteClientePorId(int id)
        {
            repository.deleteClientePorId(id);
            return NoContent();
        }
    }
}