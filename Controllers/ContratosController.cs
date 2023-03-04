using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveis.Controllers
{
    [ApiController]
    [Route("api/contratos")]
    public class ContratosController : Controller
    {
        private readonly IContratosRepository repository;

        public ContratosController(IContratosRepository repository)
        {
            this.repository = repository;
        }
        [HttpPut("atualiza-contrato/{id}")]
        public IActionResult atualizarContrato(ContratosModel contratos, int id)
        {
            ContratosModel contratosModel = repository.atualizarContrato(contratos, id);
            return Ok(contratos);
        }

        [HttpGet("{id}")]
        public IActionResult buscarContratoPorId(int id)
        {
            ContratosModel contratosModel = repository.buscarContratoPorId(id);
            return Ok(contratosModel);
        }

        [HttpGet]
        public IActionResult buscarTodosContratos()
        {
            List<ContratosModel> contratosModel = repository.buscarTodosContratos();
            return Ok(contratosModel);

        }

        [HttpPost]
        public IActionResult criarContratos(ContratosModel contratosModel)
        {
            ContratosModel contratoModel = repository.criarContratos(contratosModel);
            return Ok(contratoModel);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteContratoPorId(int id)
        {
            repository.deleteContratoPorId(id);
            return NoContent();
        }

    }
}