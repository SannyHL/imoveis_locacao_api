using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveis.Controllers
{
    [ApiController]
    [Route("api/imoveis")]
    public class ImoveisController : Controller
    {
        private readonly IImoveisRepository repository;

        public ImoveisController(IImoveisRepository repository)
        {
            this.repository = repository;
        }

        [HttpPut("atualiza-imovel/{id}")]
        public IActionResult atualizarImoveis(ImoveisModel imoveis, int id)
        {
            ImoveisModel imovelModel = repository.atualizarImoveis(imoveis, id);
            return Ok(imoveis);
        }

        [HttpGet("{id}")]
        public IActionResult buscarImoveisPorId(int id)
        {
            ImoveisModel imovelModel = repository.buscarImoveisPorId(id);
            return Ok(imovelModel);
        }

        [HttpGet]
        public IActionResult buscarTodosImoveis()
        {
            List<ImoveisModel> imovelModel = repository.buscarTodosImoveis();
            return Ok(imovelModel);

        }

        [HttpPost]
        public IActionResult criarImoveis(ImoveisModel imoveisModel)
        {
            ImoveisModel imovelModel = repository.criarImoveis(imoveisModel);
            return Ok(imovelModel);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteImoveisPorId(int id)
        {
            repository.deleteImoveisPorId(id);
            return NoContent();
        }

    }
}