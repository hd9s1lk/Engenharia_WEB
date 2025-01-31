using System.ComponentModel.DataAnnotations;

namespace Final_NOR23.Models
{
    public class Veiculo
    {
        [Key]
        public string Matricula { get; set; }

        [Required]
        public string? Marca { get; set; }

        [Required]
        public string? Modelo { get; set; }

        public virtual int ProprietarioID { get; set; }
        public virtual Proprietario? Proprietario { get; set; }
    }
}
