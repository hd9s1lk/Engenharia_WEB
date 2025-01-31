using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Estudo_Aula6.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int Number { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("ClassID")]
    public int? ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class? Class { get; set; }
}
