using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula10.Models
{
    public class Person
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
