using System.ComponentModel.DataAnnotations;

namespace REC_22.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Nome { get; set; }

        public string Logotipo { get; set; }

        public virtual int PaisID { get; set; }
        public virtual Pais? Pais { get; set; }
    }
}
