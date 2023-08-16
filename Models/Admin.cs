using System;
using System.Collections.Generic;

namespace ERPSystem.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Email { get; set; } = "";

    public string Password { get; set; } = "";
}
