using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula5.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "Coloca um valor dentro das regras")]
        public string? Title { get; set; }

        [Required]
        public string? CoverPhoto { get; set; }


    }
}
