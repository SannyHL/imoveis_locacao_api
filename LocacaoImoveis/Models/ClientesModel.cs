using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LocacaoImoveis.Models
{
    public class ClientesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string CpfCnpj { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public long NumeroCasa { get; set; }
        [Required]
        public string EnderecoCep { get; set; }
        [JsonIgnore]
        public EnderecosModel? Endereco { get; set; }
        [JsonIgnore]
        public virtual ContratosModel? Contratos { get; set; }

    }
}