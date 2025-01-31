using System.ComponentModel.DataAnnotations;

namespace Final_NOR22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Nome {  get; set; }

        [Required]
        public string Abreviatura { get; set; }

        public ICollection<Empresa>? Empresas { get; set; }
    }
}
