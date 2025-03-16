using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class PurchaseReturnDetail
{
    public long Id { get; set; }

    public long PurchaseReturnId { get; set; }

    public long? ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public int Price { get; set; }

    public int UnitPrice { get; set; }

    public int SubTotal { get; set; }

    public int ProductDiscountAmount { get; set; }

    public string ProductDiscountType { get; set; } = null!;

    public int ProductTaxAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseReturn PurchaseReturn { get; set; } = null!;
}
