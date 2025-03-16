using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class ErrorLog
{
    public long Id { get; set; }

    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public string? StackTrace { get; set; }

    public string? Type { get; set; }

    public DateTime CreatedAt { get; set; }
}
