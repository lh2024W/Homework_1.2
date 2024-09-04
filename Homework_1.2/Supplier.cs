﻿using System;
using System.Collections.Generic;

namespace Homework_1._2;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdAddress { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Address? IdAddressNavigation { get; set; }
}
