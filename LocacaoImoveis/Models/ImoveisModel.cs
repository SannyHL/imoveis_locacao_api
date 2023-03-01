using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocacaoImoveis.Models
{
    public class ImoveisModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public long NumeroCasa { get; set; }
        [Required]
        public bool Locado { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public string EnderecoCep { get; set; }
        [JsonIgnore]
        public EnderecosModel? Endereco { get; set; }
        [JsonIgnore]
        public virtual ContratosModel? Contratos { get; set; }
    }

}