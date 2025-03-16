using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class PurchaseReturnPayment
{
    public long Id { get; set; }

    public long PurchaseReturnId { get; set; }

    public int Amount { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual PurchaseReturn PurchaseReturn { get; set; } = null!;
}
