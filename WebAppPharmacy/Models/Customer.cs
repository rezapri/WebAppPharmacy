using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<SaleReturn> SaleReturns { get; set; } = new List<SaleReturn>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
