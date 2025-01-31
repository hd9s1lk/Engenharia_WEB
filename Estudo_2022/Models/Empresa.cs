using System.ComponentModel.DataAnnotations;

namespace Estudo_2022.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Erro")]
        public string? Nome { get; set; }

        public string? Logotipo { get; set; }


        public IEnumerable<Pais>? Paises { get; set; }
    }
}
