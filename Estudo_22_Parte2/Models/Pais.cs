using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Estudo_22_Parte2.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Erro")]
        public string? Abreviatura { get; set; }

        public ICollection<Empresa>? Empresas { get; set; }
    }
}
