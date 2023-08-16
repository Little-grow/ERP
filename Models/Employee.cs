using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NationalId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int? Age { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; } = new List<EmployeeLanguage>();
}
