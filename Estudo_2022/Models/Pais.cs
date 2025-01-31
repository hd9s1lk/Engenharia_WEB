using System.ComponentModel.DataAnnotations;

namespace Estudo_2022.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "Erro")]
        public string? Nome { get; set; }

        [Required]
        [StringLength(2)]
        public string? Abreviatura { get; set; }

        public IEnumerable<Empresa>? Empresas { get; set; }

    }
}
