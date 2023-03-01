using LocacaoImoveis.Models;

namespace LocacaoImoveis.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        List<ClientesModel> buscarTodosCliente();
        ClientesModel criarCliente(ClientesModel clientes);
        ClientesModel buscarClientePorId(int id);
        ClientesModel atualizarCliente(ClientesModel clientes, int id);
        void deleteClientePorId(int id);
    }
}