using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class DrugExpired
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string? BatchNumber { get; set; }

    public DateOnly ExpiredDate { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
