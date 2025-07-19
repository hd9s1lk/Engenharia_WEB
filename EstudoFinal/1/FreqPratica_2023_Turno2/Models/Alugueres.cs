using System.ComponentModel.DataAnnotations;

namespace FreqPratica_2023_Turno2.Models
{
    public class Alugueres
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Apartamento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Duracao { get; set; }

        [Required]
        public int Mensalidade { get; set; }




    }
}
