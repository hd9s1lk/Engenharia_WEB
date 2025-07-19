using System.ComponentModel.DataAnnotations;

namespace NOR_24.Models
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
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        public Regime Regime { get; set; } = Regime.Ordinario;

        [Required]
        public bool Valido { get; set; } = false;
    }
}
