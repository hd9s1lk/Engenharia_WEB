using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Final_Recurso24.Models
{
    [Index(nameof(NumAluno), IsUnique = true)]
    public class RegistoNota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumAluno { get; set; }

        [Required]
        public int Nota { get; set; }

        public string? UserName { get; set; }
    }
}
