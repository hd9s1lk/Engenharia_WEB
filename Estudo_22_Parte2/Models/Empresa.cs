using System.ComponentModel.DataAnnotations;

namespace Estudo_22_Parte2.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Nome { get; set; }

        public string? Logotipo { get; set; }

        public int PaisID { get; set; }
        public virtual Pais? Pais { get; set; }


    }
}
