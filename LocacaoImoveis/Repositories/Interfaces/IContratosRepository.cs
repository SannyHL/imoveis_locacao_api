using LocacaoImoveis.Models;

namespace LocacaoImoveis.Repositories.Interfaces
{
    public interface IContratosRepository
    {
        List<ContratosModel> buscarTodosContratos();
        ContratosModel criarContratos(ContratosModel contratos);
        ContratosModel buscarContratoPorId(int id);
        ContratosModel atualizarContrato(ContratosModel contratos, int id);
        void deleteContratoPorId(int id);
    }
}