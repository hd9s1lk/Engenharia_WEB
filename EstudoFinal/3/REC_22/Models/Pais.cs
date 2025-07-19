using System.ComponentModel.DataAnnotations;

namespace REC_22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MinLength(2)]
        public string Abreviatura { get; set; }

        public ICollection<Empresa>? Empresas { get; set; }
    }
}
