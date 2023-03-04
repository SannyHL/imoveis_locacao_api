namespace LocacaoImoveis.Models
{
    public class ClienteEndereco
    {
        public int id { get; set; }
        public ClientesModel cliente { get; set; }
        public EnderecosModel endereco { get; set; }

        public ClienteEndereco()
        {

        }
    }
}