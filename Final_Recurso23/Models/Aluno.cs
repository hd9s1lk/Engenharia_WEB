﻿using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace Final_Recurso23.Models
{
    public class Aluno
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Nome { get; set; }

        public float Pratica { get; set; }
        public float Teorica { get; set; }
        public int Nota { get; set; }
        public string? Data { get; set; }
    }
}
