using LocacaoImoveis.Models;

namespace LocacaoImoveis.Repositories
{
    public interface IEnderecosRepository
    {
        List<EnderecosModel> BuscaEnderecos();
        EnderecosModel BuscaEnderecoCep(string cep);
    }
}