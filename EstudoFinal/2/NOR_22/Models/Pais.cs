using System.ComponentModel.DataAnnotations;

namespace NOR_22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Abreviatura { get; set; }

        public virtual ICollection<Empresa>? Empresas { get; set; }
    }
}
