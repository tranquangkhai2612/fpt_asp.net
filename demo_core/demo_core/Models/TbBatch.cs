using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class TbBatch
{
    public string BatchNo { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public int Fee { get; set; }

    public int? CourseId { get; set; }

    public virtual TbCourse? Course { get; set; }
}
