using System.ComponentModel.DataAnnotations;

namespace Estudo_Exemplo1.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get;set; }

        [Required]
        [StringLength(20)]
        public string? Nome { get; set; }

        [Range(10, 1000)]
        public int? Vendas { get; set; }


        public IEnumerable<Carro>? Carros { get; set; }
    }
}
