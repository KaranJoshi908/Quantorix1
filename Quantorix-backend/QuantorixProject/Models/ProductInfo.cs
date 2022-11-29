using System;
using System.Collections.Generic;

namespace QuantorixProject.Models;

public partial class ProductInfo
{
    public int Id { get; set; }

    public string? Customer { get; set; }

    public string? Product { get; set; }

    public decimal? Price { get; set; }
}
