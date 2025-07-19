using System.ComponentModel.DataAnnotations;

namespace Pratica_2020_Turno2.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public bool Vendido { get; set; } = false;
    }
}
