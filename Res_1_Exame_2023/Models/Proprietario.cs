﻿using System.ComponentModel.DataAnnotations;

namespace Res_1_Exame_2023.Models
{
    public class Proprietario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 5)]
        public string Nome { get; set; }


        [Required]
        public string Nacionalidade { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>(); //para instanciar como não nulo




    }
}
