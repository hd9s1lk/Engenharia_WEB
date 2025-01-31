using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Res_1_Exame_2023.Models
{
    public class Veiculo
    {
        [Key]
        public string Matricula { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo {  get; set; }

        [ForeignKey("ProprietarioId")]
        public Proprietario proprietario { get; set; }

    }
}
