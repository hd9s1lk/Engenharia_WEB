using System.ComponentModel.DataAnnotations;

namespace FreqPratica2_23.Models
{
    public class BolsaInvestigacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public DateTime Mes { get; set; }

        [Required]
        public int Renumeracao { get; set; }


    }
}
