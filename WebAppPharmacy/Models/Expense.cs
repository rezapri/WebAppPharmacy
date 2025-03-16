using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Expense
{
    public long Id { get; set; }

    public long CategoryId { get; set; }

    public DateOnly Date { get; set; }

    public string Reference { get; set; } = null!;

    public string? Details { get; set; }

    public int Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ExpenseCategory Category { get; set; } = null!;
}
