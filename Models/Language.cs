using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string? LanguageName { get; set; }

    public virtual ICollection<EmployeeLanguage>? EmployeeLanguages { get; set; }

    public virtual ICollection<LanguagesLevel>? LanguagesLevels { get; set; } 
}
