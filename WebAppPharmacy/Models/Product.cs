using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Product
{
    public long Id { get; set; }

    public long CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductCode { get; set; }

    public string? ProductBarcodeSymbology { get; set; }

    public long ProductQuantity { get; set; }

    public long ProductCost { get; set; }

    public long ProductPrice { get; set; }

    public string? ProductUnit { get; set; }

    public long ProductStockAlert { get; set; }

    public long? ProductOrderTax { get; set; }

    public short? ProductTaxType { get; set; }

    public string? ProductNote { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public short IsExpired { get; set; }

    public DateTime? LastNotifiedAt { get; set; }

    public string? Manufacturer { get; set; }

    public string? BatchNumber { get; set; }

    public short IsPrescriptionRequired { get; set; }

    public short IsPublished { get; set; }

    public string? StorageInstructions { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DrugExpired> DrugExpireds { get; set; } = new List<DrugExpired>();

    public virtual ICollection<PrescriptionProduct> PrescriptionProducts { get; set; } = new List<PrescriptionProduct>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; set; } = new List<PurchaseReturnDetail>();

    public virtual ICollection<QuotationDetail> QuotationDetails { get; set; } = new List<QuotationDetail>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<SaleReturnDetail> SaleReturnDetails { get; set; } = new List<SaleReturnDetail>();

    public virtual ICollection<StockLog> StockLogs { get; set; } = new List<StockLog>();
}
