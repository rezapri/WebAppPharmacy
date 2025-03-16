using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class SaleDetail
{
    public long Id { get; set; }

    public long SaleId { get; set; }

    public long? ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public long Quantity { get; set; }

    public long Price { get; set; }

    public long UnitPrice { get; set; }

    public long SubTotal { get; set; }

    public long ProductDiscountAmount { get; set; }

    public string ProductDiscountType { get; set; } = null!;

    public long ProductTaxAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
