using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppPharmacy.Models;

public partial class WebAppPharmacyContext : DbContext
{
    public WebAppPharmacyContext()
    {
    }

    public WebAppPharmacyContext(DbContextOptions<WebAppPharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdjustedProduct> AdjustedProducts { get; set; }

    public virtual DbSet<Adjustment> Adjustments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DrugExpired> DrugExpireds { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionProduct> PrescriptionProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<PurchasePayment> PurchasePayments { get; set; }

    public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }

    public virtual DbSet<PurchaseReturnDetail> PurchaseReturnDetails { get; set; }

    public virtual DbSet<PurchaseReturnPayment> PurchaseReturnPayments { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SalePayment> SalePayments { get; set; }

    public virtual DbSet<SaleReturn> SaleReturns { get; set; }

    public virtual DbSet<SaleReturnDetail> SaleReturnDetails { get; set; }

    public virtual DbSet<SaleReturnPayment> SaleReturnPayments { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<StockLog> StockLogs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Upload> Uploads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-F1RK31SQ;Database=WebAppPharmacy;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdjustedProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adjusted__3213E83F534ADEF7");

            entity.ToTable("adjusted_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdjustmentId).HasColumnName("adjustment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Adjustment).WithMany(p => p.AdjustedProducts)
                .HasForeignKey(d => d.AdjustmentId)
                .HasConstraintName("FK_adjusted_products_adjustment_id");
        });

        modelBuilder.Entity<Adjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adjustme__3213E83FEFD4386C");

            entity.ToTable("adjustments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_categories_id");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryCode, "categories$categories_category_code_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(255)
                .HasColumnName("category_code");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_currencies_id");

            entity.ToTable("currencies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(255)
                .HasColumnName("currency_name");
            entity.Property(e => e.DecimalSeparator)
                .HasMaxLength(255)
                .HasColumnName("decimal_separator");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.Symbol)
                .HasMaxLength(255)
                .HasColumnName("symbol");
            entity.Property(e => e.ThousandSeparator)
                .HasMaxLength(255)
                .HasColumnName("thousand_separator");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_customers_id");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(255)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(255)
                .HasColumnName("customer_phone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DrugExpired>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_drug_expired_id");

            entity.ToTable("drug_expired");

            entity.HasIndex(e => e.ProductId, "drug_expired_product_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("batch_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiredDate).HasColumnName("expired_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.DrugExpireds)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("drug_expired$drug_expired_product_id_foreign");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_error_logs_id");

            entity.ToTable("error_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ErrorCode).HasColumnName("error_code");
            entity.Property(e => e.ErrorMessage).HasColumnName("error_message");
            entity.Property(e => e.StackTrace).HasColumnName("stack_trace");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_expenses_id");

            entity.ToTable("expenses");

            entity.HasIndex(e => e.CategoryId, "expenses_category_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Category).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expenses$expenses_category_id_foreign");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_expense_categories_id");

            entity.ToTable("expense_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryDescription).HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_failed_jobs_id");

            entity.ToTable("failed_jobs");

            entity.HasIndex(e => e.Uuid, "failed_jobs$failed_jobs_uuid_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection).HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.Uuid)
                .HasMaxLength(255)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_jobs_id");

            entity.ToTable("jobs");

            entity.HasIndex(e => e.Queue, "jobs_queue_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.AvailableAt).HasColumnName("available_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasMaxLength(255)
                .HasColumnName("queue");
            entity.Property(e => e.ReservedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("reserved_at");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medicines_id");

            entity.ToTable("medicines");

            entity.HasIndex(e => e.Code, "medicines$medicines_code_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("category");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Composition).HasColumnName("composition");
            entity.Property(e => e.Contraindications).HasColumnName("contraindications");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Dosage)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dosage");
            entity.Property(e => e.Indications).HasColumnName("indications");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.SideEffects).HasColumnName("side_effects");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_media_id");

            entity.ToTable("media");

            entity.HasIndex(e => e.Uuid, "media$media_uuid_unique").IsUnique();

            entity.HasIndex(e => new { e.ModelType, e.ModelId }, "media_model_type_model_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CollectionName)
                .HasMaxLength(255)
                .HasColumnName("collection_name");
            entity.Property(e => e.ConversionsDisk)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("conversions_disk");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomProperties).HasColumnName("custom_properties");
            entity.Property(e => e.Disk)
                .HasMaxLength(255)
                .HasColumnName("disk");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.GeneratedConversions).HasColumnName("generated_conversions");
            entity.Property(e => e.Manipulations).HasColumnName("manipulations");
            entity.Property(e => e.MimeType)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mime_type");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.ModelType)
                .HasMaxLength(255)
                .HasColumnName("model_type");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OrderColumn)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("order_column");
            entity.Property(e => e.ResponsiveImages).HasColumnName("responsive_images");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .HasDefaultValueSql("(NULL)")
                .IsFixedLength()
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_migrations_id");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_permissions_id");

            entity.ToTable("permissions");

            entity.HasIndex(e => new { e.Name, e.GuardName }, "permissions$permissions_name_guard_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GuardName)
                .HasMaxLength(255)
                .HasColumnName("guard_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_prescriptions_id");

            entity.ToTable("prescriptions");

            entity.HasIndex(e => e.PrescriptionCode, "prescriptions$prescriptions_prescription_code_unique").IsUnique();

            entity.HasIndex(e => e.CustomerId, "prescriptions_customer_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("customer_id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("doctor_name");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PrescriptionCode)
                .HasMaxLength(255)
                .HasColumnName("prescription_code");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("prescriptions$prescriptions_customer_id_foreign");
        });

        modelBuilder.Entity<PrescriptionProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_prescription_product_id");

            entity.ToTable("prescription_product");

            entity.HasIndex(e => e.PrescriptionId, "prescription_product_prescription_id_foreign");

            entity.HasIndex(e => e.ProductId, "prescription_product_product_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionProducts)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("prescription_product$prescription_product_prescription_id_foreign");

            entity.HasOne(d => d.Product).WithMany(p => p.PrescriptionProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("prescription_product$prescription_product_product_id_foreign");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_products_id");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductCode, "products$products_product_code_unique").IsUnique();

            entity.HasIndex(e => e.CategoryId, "products_category_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("batch_number");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpirationDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("expiration_date");
            entity.Property(e => e.IsExpired).HasColumnName("is_expired");
            entity.Property(e => e.IsPrescriptionRequired).HasColumnName("is_prescription_required");
            entity.Property(e => e.IsPublished)
                .HasDefaultValue((short)1)
                .HasColumnName("is_published");
            entity.Property(e => e.LastNotifiedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_notified_at");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("manufacturer");
            entity.Property(e => e.ProductBarcodeSymbology)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_barcode_symbology");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_code");
            entity.Property(e => e.ProductCost).HasColumnName("product_cost");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductNote).HasColumnName("product_note");
            entity.Property(e => e.ProductOrderTax)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_order_tax");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.ProductStockAlert).HasColumnName("product_stock_alert");
            entity.Property(e => e.ProductTaxType)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_tax_type");
            entity.Property(e => e.ProductUnit)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_unit");
            entity.Property(e => e.StorageInstructions)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("storage_instructions");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products$products_category_id_foreign");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchases_id");

            entity.ToTable("purchases");

            entity.HasIndex(e => e.SupplierId, "purchases_supplier_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.DueAmount).HasColumnName("due_amount");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.ShippingAmount).HasColumnName("shipping_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.SupplierId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("supplier_id");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxPercentage).HasColumnName("tax_percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("purchases$purchases_supplier_id_foreign");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase_details_id");

            entity.ToTable("purchase_details");

            entity.HasIndex(e => e.ProductId, "purchase_details_product_id_foreign");

            entity.HasIndex(e => e.PurchaseId, "purchase_details_purchase_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductDiscountType)
                .HasMaxLength(255)
                .HasDefaultValue("fixed")
                .HasColumnName("product_discount_type");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTaxAmount).HasColumnName("product_tax_amount");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("purchase_details$purchase_details_product_id_foreign");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("purchase_details$purchase_details_purchase_id_foreign");
        });

        modelBuilder.Entity<PurchasePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase_payments_id");

            entity.ToTable("purchase_payments");

            entity.HasIndex(e => e.PurchaseId, "purchase_payments_purchase_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchasePayments)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("purchase_payments$purchase_payments_purchase_id_foreign");
        });

        modelBuilder.Entity<PurchaseReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase_returns_id");

            entity.ToTable("purchase_returns");

            entity.HasIndex(e => e.SupplierId, "purchase_returns_supplier_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.DueAmount).HasColumnName("due_amount");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.ShippingAmount).HasColumnName("shipping_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.SupplierId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("supplier_id");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxPercentage).HasColumnName("tax_percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseReturns)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("purchase_returns$purchase_returns_supplier_id_foreign");
        });

        modelBuilder.Entity<PurchaseReturnDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase_return_details_id");

            entity.ToTable("purchase_return_details");

            entity.HasIndex(e => e.ProductId, "purchase_return_details_product_id_foreign");

            entity.HasIndex(e => e.PurchaseReturnId, "purchase_return_details_purchase_return_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductDiscountType)
                .HasMaxLength(255)
                .HasDefaultValue("fixed")
                .HasColumnName("product_discount_type");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTaxAmount).HasColumnName("product_tax_amount");
            entity.Property(e => e.PurchaseReturnId).HasColumnName("purchase_return_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseReturnDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("purchase_return_details$purchase_return_details_product_id_foreign");

            entity.HasOne(d => d.PurchaseReturn).WithMany(p => p.PurchaseReturnDetails)
                .HasForeignKey(d => d.PurchaseReturnId)
                .HasConstraintName("purchase_return_details$purchase_return_details_purchase_return_id_foreign");
        });

        modelBuilder.Entity<PurchaseReturnPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase_return_payments_id");

            entity.ToTable("purchase_return_payments");

            entity.HasIndex(e => e.PurchaseReturnId, "purchase_return_payments_purchase_return_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PurchaseReturnId).HasColumnName("purchase_return_id");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.PurchaseReturn).WithMany(p => p.PurchaseReturnPayments)
                .HasForeignKey(d => d.PurchaseReturnId)
                .HasConstraintName("purchase_return_payments$purchase_return_payments_purchase_return_id_foreign");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_quotations_id");

            entity.ToTable("quotations");

            entity.HasIndex(e => e.CustomerId, "quotations_customer_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.ShippingAmount).HasColumnName("shipping_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxPercentage).HasColumnName("tax_percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("quotations$quotations_customer_id_foreign");
        });

        modelBuilder.Entity<QuotationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_quotation_details_id");

            entity.ToTable("quotation_details");

            entity.HasIndex(e => e.ProductId, "quotation_details_product_id_foreign");

            entity.HasIndex(e => e.QuotationId, "quotation_details_quotation_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductDiscountType)
                .HasMaxLength(255)
                .HasDefaultValue("fixed")
                .HasColumnName("product_discount_type");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTaxAmount).HasColumnName("product_tax_amount");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.QuotationId).HasColumnName("quotation_id");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.QuotationDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("quotation_details$quotation_details_product_id_foreign");

            entity.HasOne(d => d.Quotation).WithMany(p => p.QuotationDetails)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("quotation_details$quotation_details_quotation_id_foreign");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sales_id");

            entity.ToTable("sales");

            entity.HasIndex(e => e.CustomerId, "sales_customer_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.DueAmount).HasColumnName("due_amount");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.ShippingAmount).HasColumnName("shipping_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxPercentage).HasColumnName("tax_percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sales$sales_customer_id_foreign");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sale_details_id");

            entity.ToTable("sale_details");

            entity.HasIndex(e => e.ProductId, "sale_details_product_id_foreign");

            entity.HasIndex(e => e.SaleId, "sale_details_sale_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductDiscountType)
                .HasMaxLength(255)
                .HasDefaultValue("fixed")
                .HasColumnName("product_discount_type");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTaxAmount).HasColumnName("product_tax_amount");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_details$sale_details_product_id_foreign");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("sale_details$sale_details_sale_id_foreign");
        });

        modelBuilder.Entity<SalePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sale_payments_id");

            entity.ToTable("sale_payments");

            entity.HasIndex(e => e.SaleId, "sale_payments_sale_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Sale).WithMany(p => p.SalePayments)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("sale_payments$sale_payments_sale_id_foreign");
        });

        modelBuilder.Entity<SaleReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sale_returns_id");

            entity.ToTable("sale_returns");

            entity.HasIndex(e => e.CustomerId, "sale_returns_customer_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.DueAmount).HasColumnName("due_amount");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.ShippingAmount).HasColumnName("shipping_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxPercentage).HasColumnName("tax_percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_returns$sale_returns_customer_id_foreign");
        });

        modelBuilder.Entity<SaleReturnDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sale_return_details_id");

            entity.ToTable("sale_return_details");

            entity.HasIndex(e => e.ProductId, "sale_return_details_product_id_foreign");

            entity.HasIndex(e => e.SaleReturnId, "sale_return_details_sale_return_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductDiscountType)
                .HasMaxLength(255)
                .HasDefaultValue("fixed")
                .HasColumnName("product_discount_type");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTaxAmount).HasColumnName("product_tax_amount");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleReturnDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_return_details$sale_return_details_product_id_foreign");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.SaleReturnDetails)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("sale_return_details$sale_return_details_sale_return_id_foreign");
        });

        modelBuilder.Entity<SaleReturnPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sale_return_payments_id");

            entity.ToTable("sale_return_payments");

            entity.HasIndex(e => e.SaleReturnId, "sale_return_payments_sale_return_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasColumnName("reference");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.SaleReturnPayments)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("sale_return_payments$sale_return_payments_sale_return_id_foreign");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_settings_id");

            entity.ToTable("settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyAddress).HasColumnName("company_address");
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(255)
                .HasColumnName("company_email");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(255)
                .HasColumnName("company_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultCurrencyId).HasColumnName("default_currency_id");
            entity.Property(e => e.DefaultCurrencyPosition)
                .HasMaxLength(255)
                .HasColumnName("default_currency_position");
            entity.Property(e => e.FooterText).HasColumnName("footer_text");
            entity.Property(e => e.NotificationEmail)
                .HasMaxLength(255)
                .HasColumnName("notification_email");
            entity.Property(e => e.SiteLogo)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("site_logo");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<StockLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_stock_logs_id");

            entity.ToTable("stock_logs");

            entity.HasIndex(e => e.ProductId, "stock_logs_product_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangeQuantity).HasColumnName("change_quantity");
            entity.Property(e => e.ChangeReason).HasColumnName("change_reason");
            entity.Property(e => e.ChangeType)
                .HasMaxLength(255)
                .HasColumnName("change_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("created_by");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Product).WithMany(p => p.StockLogs)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("stock_logs$stock_logs_product_id_foreign");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suppliers_id");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(255)
                .HasColumnName("supplier_email");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(255)
                .HasColumnName("supplier_phone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_units_id");

            entity.ToTable("units");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
            entity.Property(e => e.OperationValue)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("operation_value");
            entity.Property(e => e.Operator)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("operator");
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("short_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Upload>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_uploads_id");

            entity.ToTable("uploads");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Folder)
                .HasMaxLength(255)
                .HasColumnName("folder");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
