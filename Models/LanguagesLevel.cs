using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class LanguagesLevel
{
    public int Id { get; set; }

    public int LanguageId { get; set; }

    public string? LanguageLevel { get; set; }

    public virtual Language Language { get; set; } = null!;
}
