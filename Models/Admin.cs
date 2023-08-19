using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models;

public partial class Admin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; } = "";
    [Required]
    [Column(TypeName = "varbinary(MAX)")]
    public byte[]? Password { get; set; } 
    [Column(TypeName = "varbinary(MAX)")]
    public byte[]? SaltKey { get; set; }
}
