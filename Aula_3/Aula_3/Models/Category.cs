﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aula_3.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Required Field")]
		[StringLength(50, MinimumLength = 3, ErrorMessage ="{0} length must be between {2} and {1}")]

		public string? Name { get; set; }

		[Required(ErrorMessage ="Required Field")]
		[MaxLength(256,ErrorMessage ="{0} length can not exceed {1} characters")]
		public string? Description { get; set; }

		public Boolean State {  get; set; }

		[DisplayName("Creation Date")]
		public DateTime Date { get; set; } = DateTime.Now;
	}
}
