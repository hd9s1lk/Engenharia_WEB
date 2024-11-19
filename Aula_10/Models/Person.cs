using System.ComponentModel.DataAnnotations;

namespace Aula_10.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
