using System.ComponentModel.DataAnnotations;

namespace REC_23.Models
{
    public class Aluno
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        [StringLength(256,MinimumLength = 20)]
        public string? Nome { get; set; }

        public float? Pratica { get; set; }
        public float? Teorica { get; set; }
        public int? Nota { get; set; }

        public string? Data { get; set; }


    }
}
