using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Nome { get; set; }

        public string? Abreviatura {get;set;}

        public ICollection<Empresa>? Empresas { get; set; }

    }
}
