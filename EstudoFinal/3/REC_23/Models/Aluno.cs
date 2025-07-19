using System.ComponentModel.DataAnnotations;

namespace REC_23.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1}")]
        public float Pratica { get; set; }
        public float Teorica { get; set; }
        public int Nota { get; set; }
        public DateTime Data { get; set; }
    }
}
