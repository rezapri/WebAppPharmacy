using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Supplier
{
    public long Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierEmail { get; set; } = null!;

    public string SupplierPhone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
