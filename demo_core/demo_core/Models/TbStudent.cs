using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class TbStudent
{
    public string? StudentId { get; set; }

    public string? StudentName { get; set; }

    public int? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public int? Phone { get; set; }
}
