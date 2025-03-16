using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Adjustment
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AdjustedProduct> AdjustedProducts { get; set; } = new List<AdjustedProduct>();
}
