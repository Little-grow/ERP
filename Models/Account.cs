using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<LinesOfBusiness> LinesOfBusinesses { get; set; } = new List<LinesOfBusiness>();
}
