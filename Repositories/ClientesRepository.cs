using LocacaoImoveis.Data;
using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;
using LocacaoImoveis.utils;

namespace LocacaoImoveis.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly DBContext context;
        private readonly IEnderecosRepository enderecosRepository;

        public ClientesRepository(DBContext context, IEnderecosRepository enderecosRepository)
        {
            this.context = context;
            this.enderecosRepository = enderecosRepository;
        }



        public ClientesModel atualizarCliente(ClientesModel clientes, int id)
        {
            var verificaCliente = buscarClientePorId(id);
            if (verificaCliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado");
            }
            var cep = MethodsUtils.buscaCep(clientes.EnderecoCep);
            EnderecosModel verificaEndereco = enderecosRepository.BuscaEnderecoCep(cep.Cep);
            if (verificaEndereco == null)
            {
                context.Enderecos.Add(cep);
                context.SaveChanges();
            }
            verificaCliente.Id = verificaCliente.Id;
            verificaCliente.Endereco = cep ?? verificaCliente.Endereco;
            verificaCliente.EnderecoCep = clientes.EnderecoCep ?? verificaCliente.EnderecoCep;
            verificaCliente.CpfCnpj = clientes.CpfCnpj ?? verificaCliente.CpfCnpj;
            verificaCliente.Email = clientes.Email ?? verificaCliente.Email;
            verificaCliente.Nome = clientes.Nome ?? verificaCliente.Nome;
            verificaCliente.NumeroCasa = clientes.NumeroCasa != null ? clientes.NumeroCasa : verificaCliente.NumeroCasa;
            verificaCliente.Telefone = clientes.Telefone ?? verificaCliente.Telefone;
            context.Update(verificaCliente);
            context.SaveChanges();
            return verificaCliente;
        }

        public ClientesModel buscarClientePorId(int id)
        {
            return context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClientesModel> buscarTodosCliente()
        {
            return context.Clientes.ToList();
        }

        public ClientesModel criarCliente(ClientesModel clientes)
        {
            var cep = MethodsUtils.buscaCep(clientes.EnderecoCep);
            EnderecosModel verificaEndereco = enderecosRepository.BuscaEnderecoCep(clientes.EnderecoCep);
            if (verificaEndereco == null)
            {
                context.Enderecos.Add(cep);
                context.SaveChanges();
            }

            clientes.Endereco = cep;
            context.Clientes.Add(clientes);
            context.SaveChanges();
            return clientes;
        }

        public void deleteClientePorId(int id)
        {

            var cliente = buscarClientePorId(id);
            if (cliente != null)
            {
                context.Remove(cliente);
                context.SaveChanges();
            }

        }

    }
}