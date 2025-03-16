using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class SaleReturnPayment
{
    public long Id { get; set; }

    public long SaleReturnId { get; set; }

    public int Amount { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SaleReturn SaleReturn { get; set; } = null!;
}
