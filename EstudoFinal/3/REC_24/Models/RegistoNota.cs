using System.ComponentModel.DataAnnotations;

namespace REC_24.Models
{
    public class RegistoNota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumAluno { get; set; }

        [Required]
        [Range(0,20)]
        public int Nota { get; set; }

        public string? Username { get; set; }
    }
}
