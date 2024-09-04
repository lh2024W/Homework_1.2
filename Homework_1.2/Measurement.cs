﻿using System;
using System.Collections.Generic;

namespace Homework_1._2;

public partial class Measurement
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
