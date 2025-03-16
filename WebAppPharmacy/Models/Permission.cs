using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Permission
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string GuardName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
