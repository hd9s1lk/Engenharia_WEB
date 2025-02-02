﻿using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula3.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Credits { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }


    }
}
