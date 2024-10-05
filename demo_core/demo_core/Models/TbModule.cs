using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class TbModule
{
    public string? ModuleId { get; set; }

    public string? ModuleName { get; set; }

    public int? Hours { get; set; }

    public int? Fee { get; set; }
}
