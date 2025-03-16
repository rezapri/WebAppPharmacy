using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class StockLog
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long ChangeQuantity { get; set; }

    public string ChangeType { get; set; } = null!;

    public string? ChangeReason { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
