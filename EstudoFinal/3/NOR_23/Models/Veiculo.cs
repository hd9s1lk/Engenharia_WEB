using System.ComponentModel.DataAnnotations;

namespace NOR_23.Models
{
    public class Veiculo
    {
        [Key]
        public string Matricula { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        public virtual int ProprietarioId { get; set; }
        public virtual Proprietario? Proprietario { get; set; }
    }
}
