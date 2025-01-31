using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR2024.Models
{
    public enum Regime
    {
        Ordinario,
        Especial,
        Super
    }
    public class RegistoUtilizador
    {
        [Key]
        public int RegistoId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Erro")]
        public string? Nome { get; set; }

        [Required]
        public Regime Regime { get; set; } = Regime.Ordinario;

        public bool Valido { get; set; } = false;

    }
}
