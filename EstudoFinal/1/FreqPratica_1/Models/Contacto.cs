using System.ComponentModel.DataAnnotations;

namespace FreqPratica_1.Models
{
    public class Contacto
    {
        [Key]
        public string Email { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string NickName { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool Amigo { get; set; } = false;





    }
}
