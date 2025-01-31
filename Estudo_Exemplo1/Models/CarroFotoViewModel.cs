using System.ComponentModel.DataAnnotations;

namespace Estudo_Exemplo1.Models
{
    public class CarroFotoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Marca { get; set; }

        [Required]
        public IFormFile? Fotografia { get; set; }


    }
}
