using LocacaoImoveis.Data;
using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;

namespace LocacaoImoveis.Repositories
{
    public class ContratosRepository : IContratosRepository
    {
        private readonly DBContext context;
        private readonly IClientesRepository clientesRepository;
        private readonly IImoveisRepository imoveisRepository;

        public ContratosRepository(DBContext context, IClientesRepository clientesRepository, IImoveisRepository imoveisRepository)
        {
            this.context = context;
            this.clientesRepository = clientesRepository;
            this.imoveisRepository = imoveisRepository;
        }
        public ContratosModel atualizarContrato(ContratosModel contratos, int id)
        {
            var verificaContrato = buscarContratoPorId(id);
            if (verificaContrato == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado");
            }
            ClientesModel clientesModel = clientesRepository.buscarClientePorId(contratos.ClientesId);
            if (clientesModel == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            ImoveisModel verificaImovel = imoveisRepository.buscarImoveisPorId(contratos.ImovelId);
            if (verificaImovel == null)
            {
                throw new Exception("Imovel não encontrado");
            }
            verificaContrato.Id = verificaContrato.Id;
            verificaContrato.ClientesId = clientesModel.Id;
            verificaContrato.ImovelId = verificaImovel.Id;
            verificaContrato.Ativo = contratos.Ativo != null ? contratos.Ativo : verificaContrato.Ativo;
            verificaContrato.ValorLocacao = contratos.ValorLocacao != null ? contratos.ValorLocacao : verificaContrato.ValorLocacao;
            verificaContrato.DataInicio = contratos.DataInicio == new DateTime() ? contratos.DataInicio : verificaContrato.DataInicio;
            verificaContrato.DataFim = contratos.DataFim == new DateTime() ? contratos.DataFim : verificaContrato.DataFim;
            context.Update(verificaContrato);
            context.SaveChanges();
            return verificaContrato;
        }

        public ContratosModel buscarContratoPorId(int id)
        {
            return context.Contratos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContratosModel> buscarTodosContratos()
        {
            return context.Contratos.ToList();
        }

        public ContratosModel criarContratos(ContratosModel contratos)
        {

            ClientesModel clientesModel = clientesRepository.buscarClientePorId(contratos.ClientesId);
            if (clientesModel == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            ImoveisModel verificaImovel = imoveisRepository.buscarImoveisPorId(contratos.ImovelId);
            if (verificaImovel == null)
            {
                throw new Exception("Imovel não encontrado");
            }
            contratos.ClientesId = clientesModel.Id;
            contratos.ImovelId = verificaImovel.Id;
            contratos.Clientes = clientesModel;
            contratos.Imovel = verificaImovel;
            context.Contratos.Add(contratos);
            context.SaveChanges();
            return contratos;
        }

        public void deleteContratoPorId(int id)
        {
            var contratos = buscarContratoPorId(id);
            if (contratos != null)
            {
                context.Remove(contratos);
                context.SaveChanges();
            }
        }
    }
}