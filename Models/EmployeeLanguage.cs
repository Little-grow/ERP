using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class EmployeeLanguage
{
    public int EmplpoyeeLangaugeId { get; set; }

    public int? EmployeeId { get; set; }

    public int? LanguageId { get; set; }

    public string? LanguageLevel { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Language? Language { get; set; }
}
