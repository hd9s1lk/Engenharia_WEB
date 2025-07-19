using System.ComponentModel.DataAnnotations;

namespace Aula_3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Está mal")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Required Field")]
        [MaxLength(256,ErrorMessage ="está mal")]
        public string? Description { get; set; }

        public Boolean State { get; set; }


    }
}
