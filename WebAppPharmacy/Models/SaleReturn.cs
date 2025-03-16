using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class SaleReturn
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public long? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int TaxPercentage { get; set; }

    public int TaxAmount { get; set; }

    public int DiscountPercentage { get; set; }

    public int DiscountAmount { get; set; }

    public int ShippingAmount { get; set; }

    public int TotalAmount { get; set; }

    public int PaidAmount { get; set; }

    public int DueAmount { get; set; }

    public string Status { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SaleReturnDetail> SaleReturnDetails { get; set; } = new List<SaleReturnDetail>();

    public virtual ICollection<SaleReturnPayment> SaleReturnPayments { get; set; } = new List<SaleReturnPayment>();
}
