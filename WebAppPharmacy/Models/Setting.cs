using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Setting
{
    public long Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyEmail { get; set; } = null!;

    public string CompanyPhone { get; set; } = null!;

    public string? SiteLogo { get; set; }

    public int DefaultCurrencyId { get; set; }

    public string DefaultCurrencyPosition { get; set; } = null!;

    public string NotificationEmail { get; set; } = null!;

    public string FooterText { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
