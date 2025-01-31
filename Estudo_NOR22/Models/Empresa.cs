using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR22.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Logotipo { get; set; }

        public int PaisID { get; set; }
        public virtual Pais? Pais { get; set; }
    }
}
