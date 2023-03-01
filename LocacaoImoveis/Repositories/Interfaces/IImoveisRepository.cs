using LocacaoImoveis.Models;

namespace LocacaoImoveis.Repositories.Interfaces
{
    public interface IImoveisRepository
    {
        List<ImoveisModel> buscarTodosImoveis();
        ImoveisModel criarImoveis(ImoveisModel imoveis);
        ImoveisModel buscarImoveisPorId(int id);
        ImoveisModel atualizarImoveis(ImoveisModel imoveis, int id);
        void deleteImoveisPorId(int id);
    }
}