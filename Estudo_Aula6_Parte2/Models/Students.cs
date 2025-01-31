using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula6_Parte2.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
