﻿using System.ComponentModel.DataAnnotations;

namespace Estudo_NOR2023.Models
{
    public class Proprietario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string? Nome { get; set; }

        [Required]
        public string? Nacionalidade { get; set; }

        public virtual ICollection<Veiculo>? Veiculos { get; set; }
    }
}
