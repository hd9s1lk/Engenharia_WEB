using System.ComponentModel.DataAnnotations;

namespace Final_REC22.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(2, MinimumLength =2)]
        public string Abreviatura { get; set; }

        public ICollection<Empresa>? Empresas { get; set; }


    }
}
