﻿using System;
using System.Collections.Generic;

namespace Homework_1._2;

public partial class Region
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? IdCountryNavigation { get; set; }
}
