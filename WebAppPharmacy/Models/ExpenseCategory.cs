using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class ExpenseCategory
{
    public long Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
