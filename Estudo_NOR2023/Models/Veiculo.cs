using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR2023.Models
{
    public class Veiculo
    {
        [Key]
        public string? Matricula { get; set; }

        [Required]
        public string? Marca { get; set; }

        [Required]
        public string? Modelo { get; set; }

        public int ProprietarioID { get; set; }
        public virtual Proprietario? proprietario { get; set; }
    }
}
