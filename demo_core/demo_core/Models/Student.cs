using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class Student
{
    public string StudentName { get; set; } = null!;

    public string Course { get; set; } = null!;

    public int Mark { get; set; }
}
