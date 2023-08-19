using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string NationalId { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public int? Age { get; set; }

    public int? AccountId { get; set; }
}
