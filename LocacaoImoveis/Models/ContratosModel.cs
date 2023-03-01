using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocacaoImoveis.Models
{
    public class ContratosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public double ValorLocacao { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataInicio { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataFim { get; set; }
        [Required]
        public Boolean Ativo { get; set; }
        [Required]

        public int ClientesId { get; set; }
        [JsonIgnore]
        public ClientesModel? Clientes { get; set; }
        [Required]

        public int ImovelId { get; set; }
        [JsonIgnore]
        public ImoveisModel? Imovel { get; set; }

    }
}