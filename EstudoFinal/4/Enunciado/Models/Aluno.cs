using System.ComponentModel.DataAnnotations;

namespace Enunciado.Models
{
    public class Aluno
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Data_Nascimento { get; set; }


    }
}
