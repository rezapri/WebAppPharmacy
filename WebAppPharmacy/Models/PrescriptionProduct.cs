using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class PrescriptionProduct
{
    public long Id { get; set; }

    public long PrescriptionId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Prescription Prescription { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
