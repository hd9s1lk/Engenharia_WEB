using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR22.Models
{
    public class EmpresaFotoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public IFormFile? Logotipo { get; set; }
    }
}
