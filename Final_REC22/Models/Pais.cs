using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_REC22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [StringLength(2)]
        public string? Abreviatura { get; set; }

        public virtual ICollection<Empresa>? Empresas { get; set; }

    }
}
