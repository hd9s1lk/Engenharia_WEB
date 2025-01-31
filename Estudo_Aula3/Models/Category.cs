﻿using System.ComponentModel.DataAnnotations;

namespace Estudo_Aula3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string? Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "{0} length can not exceed {1} characters")]
        public string? Description { get; set; }

        public Boolean State { get; set; } = true;

        public ICollection<Course> Courses { get; set; }
        

    }
}
