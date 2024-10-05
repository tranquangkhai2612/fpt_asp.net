using System;
using System.Collections.Generic;

namespace demo_core.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }
}
