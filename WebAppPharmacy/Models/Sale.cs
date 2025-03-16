using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Sale
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public long? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public long TaxPercentage { get; set; }

    public long TaxAmount { get; set; }

    public long DiscountPercentage { get; set; }

    public long DiscountAmount { get; set; }

    public long ShippingAmount { get; set; }

    public long TotalAmount { get; set; }

    public long PaidAmount { get; set; }

    public long DueAmount { get; set; }

    public string Status { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<SalePayment> SalePayments { get; set; } = new List<SalePayment>();
}
