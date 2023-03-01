using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocacaoImoveis.Models
{
    public class EnderecosModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Cep { get; set; }

        public string? Logradouro { get; set; }

        public string? Bairro { get; set; }

        public string? Localidade { get; set; }

        public string? Uf { get; set; }
        [JsonIgnore]
        public virtual List<ClientesModel>? Cliente { get; set; }
        [JsonIgnore]
        public virtual List<ImoveisModel>? Imoveis { get; set; }

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}