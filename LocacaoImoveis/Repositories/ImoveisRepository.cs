using LocacaoImoveis.Data;
using LocacaoImoveis.Models;
using LocacaoImoveis.Repositories.Interfaces;
using LocacaoImoveis.utils;

namespace LocacaoImoveis.Repositories
{
    public class ImoveisRepository : IImoveisRepository
    {

        private readonly DBContext context;
        private readonly IEnderecosRepository enderecosRepository;

        public ImoveisRepository(DBContext context, IEnderecosRepository enderecosRepository)
        {
            this.context = context;
            this.enderecosRepository = enderecosRepository;
        }
        public ImoveisModel atualizarImoveis(ImoveisModel imoveis, int id)
        {
            var verificaImovel = buscarImoveisPorId(id);
            if (verificaImovel == null)
            {
                throw new KeyNotFoundException("Imóvel não encontrado");
            }
            var cep = MethodsUtils.buscaCep(imoveis.EnderecoCep);
            EnderecosModel verificaEndereco = enderecosRepository.BuscaEnderecoCep(cep.Cep);
            if (verificaEndereco == null)
            {
                context.Enderecos.Add(cep);
                context.SaveChanges();
            }
            verificaImovel.Id = verificaImovel.Id;
            verificaImovel.Endereco = cep ?? verificaImovel.Endereco;
            verificaImovel.EnderecoCep = imoveis.EnderecoCep ?? verificaImovel.EnderecoCep;
            verificaImovel.Ativo = imoveis.Ativo != null ? imoveis.Ativo : verificaImovel.Ativo;
            verificaImovel.NumeroCasa = imoveis.NumeroCasa != null ? imoveis.NumeroCasa : verificaImovel.NumeroCasa;
            verificaImovel.Locado = imoveis.Locado != null ? imoveis.Locado : imoveis.Locado;
            context.Update(verificaImovel);
            context.SaveChanges();
            return verificaImovel;
        }

        public ImoveisModel buscarImoveisPorId(int id)
        {
            return context.Imoveis.FirstOrDefault(x => x.Id == id);
        }

        public List<ImoveisModel> buscarTodosImoveis()
        {
            return context.Imoveis.ToList();
        }

        public ImoveisModel criarImoveis(ImoveisModel imoveis)
        {
            var cep = MethodsUtils.buscaCep(imoveis.EnderecoCep);
            EnderecosModel verificaEndereco = enderecosRepository.BuscaEnderecoCep(imoveis.EnderecoCep);
            if (verificaEndereco == null)
            {
                context.Enderecos.Add(cep);
                context.SaveChanges();
            }

            imoveis.Endereco = cep;
            context.Imoveis.Add(imoveis);
            context.SaveChanges();
            return imoveis;
        }

        public void deleteImoveisPorId(int id)
        {
            var imoveis = buscarImoveisPorId(id);
            if (imoveis != null)
            {
                context.Remove(imoveis);
                context.SaveChanges();
            }
        }
    }
}