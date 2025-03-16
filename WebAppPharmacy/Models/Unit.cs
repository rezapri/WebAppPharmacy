using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Unit
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? Operator { get; set; }

    public int? OperationValue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
