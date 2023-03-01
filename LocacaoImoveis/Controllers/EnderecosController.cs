using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveis.Controllers
{
    [ApiController]
    [Route("api/endereco")]
    public class EnderecosController : Controller
    {
        private readonly IEnderecosRepository repository;

        public EnderecosController(Repositories.IEnderecosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult BuscaEnderecosCep()
        {
            List<EnderecosModel> enderecos = this.repository.BuscaEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{cep}")]
        public IActionResult BuscaEnderecoCep(string cep)
        {
            var enderecos = this.repository.BuscaEnderecoCep(cep);
            if (enderecos == null)
            {
                throw new Exception("Endereço não encontrado");
            }
            return Ok(enderecos);
        }

    }
}