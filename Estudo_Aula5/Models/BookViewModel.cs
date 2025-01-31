using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula5.Models
{
    public class BookViewModel
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public IFormFile? CoverPhoto { get; set; }


    }
}
