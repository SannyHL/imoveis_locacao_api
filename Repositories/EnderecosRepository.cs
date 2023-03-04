using LocacaoImoveis.Data;
using LocacaoImoveis.Models;

namespace LocacaoImoveis.Repositories
{
    public class EnderecosRepository : IEnderecosRepository
    {
        private readonly DBContext context;

        public EnderecosRepository(DBContext context)
        {
            this.context = context;
        }

        public EnderecosModel BuscaEnderecoCep(string cep)
        {
            EnderecosModel endereco = context.Enderecos.Where(x => x.Cep == cep).FirstOrDefault();
            if (endereco == null)
            {
                return endereco = null;
            }
            return endereco;
        }

        public List<EnderecosModel> BuscaEnderecos()
        {
            return context.Enderecos.ToList();
        }
    }
}