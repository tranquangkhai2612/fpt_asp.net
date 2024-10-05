using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class TbCourse
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int? Fee { get; set; }

    public int? Duration { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<TbBatch> TbBatches { get; set; } = new List<TbBatch>();
}
