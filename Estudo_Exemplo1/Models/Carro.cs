using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Estudo_Exemplo1.Models
{
    [Index(nameof(Marca), IsUnique = true)]
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "A marca tem de ter entre {0} e {1} caracteres")]
        public string? Marca { get; set; }

        public string? Fotografia { get; set; }

        public IEnumerable<Pessoa>? Pessoas { get; set; }

    }
}
