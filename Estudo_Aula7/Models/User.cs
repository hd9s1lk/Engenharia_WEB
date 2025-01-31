﻿using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula7.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
