using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Medicine
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Composition { get; set; } = null!;

    public string Indications { get; set; } = null!;

    public string? Contraindications { get; set; }

    public string? Dosage { get; set; }

    public string? SideEffects { get; set; }

    public string? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
