using System.ComponentModel.DataAnnotations;

namespace Final_NOR24.Models
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
        [StringLength(200, ErrorMessage ="Erro")]
        public string? Nome { get; set; }

        public Regime Regime { get; set; } = Regime.Ordinario;

        public bool Valido { get; set; } = false;




    }
}
