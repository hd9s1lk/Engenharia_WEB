using System.ComponentModel.DataAnnotations;

namespace Papp1_pratica_v1.Models
{
    public class Carro
    {
        [Key]
        public string Marca { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public bool Vendido { get; set; } = false;
    }
}
