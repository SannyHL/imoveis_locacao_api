using LocacaoImoveis.Models;
using Newtonsoft.Json;
using RestSharp;

namespace LocacaoImoveis.utils
{
    public class MethodsUtils
    {
        private const string ViaCepUrl = "https://viacep.com.br";
        public static EnderecosModel buscaCep(string cep)
        {

            var cliente = new RestClient(ViaCepUrl);
            var requisicao = new RestRequest($"/ws/{cep}/json", Method.Get);
            var resposta = cliente.Execute(requisicao);

            if (!resposta.Content.Equals("{\n  \"erro\": true\n}"))
            {
                return JsonConvert.DeserializeObject<EnderecosModel>(resposta.Content);
            }
            else
            {
                throw new Exception($"Cep não localizado");
            }
        }
    }
}