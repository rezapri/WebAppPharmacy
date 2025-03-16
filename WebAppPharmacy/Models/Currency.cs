using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Currency
{
    public long Id { get; set; }

    public string CurrencyName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string ThousandSeparator { get; set; } = null!;

    public string DecimalSeparator { get; set; } = null!;

    public int? ExchangeRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
