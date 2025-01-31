using System.ComponentModel.DataAnnotations;

namespace Estudo_Pratica2023.Models
{
    public class Aluno
    {
        [Key]
        public string? Numero { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Nome { get; set; }

        [Range(0.0, 20.0)]
        public float? Pratica { get; set; }

        [Range(0.0, 20.0)]
        public float? Teorica { get; set; }

        public int Nota { get; set; }

        public string? Data {  get; set; }


    }
}
