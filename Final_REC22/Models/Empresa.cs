using System.ComponentModel.DataAnnotations;

namespace Final_REC22.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 5)]
        public string? Nome { get; set; }

        public string? Logotipo { get; set; }

        public virtual int PaisID { get; set; }
        public virtual Pais? Pais { get; set; }


    }
}
