using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class LinesOfBusiness
{
    public int LineOfBusinessId { get; set; }

    public string? LineOfBusinessName { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }
}
