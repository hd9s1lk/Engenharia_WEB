using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Final2_REC24.Models
{
    [Index(nameof(NumAluno), IsUnique = true)]
    public class RegistoNota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumAluno { get; set; }

        [Required]
        [Range(0,20)]
        public int Nota { get; set; }

        public string? UserName { get; set; }
    }
}
