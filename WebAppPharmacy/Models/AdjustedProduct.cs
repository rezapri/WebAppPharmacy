using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class AdjustedProduct
{
    public long Id { get; set; }

    public long AdjustmentId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Adjustment Adjustment { get; set; } = null!;
}
