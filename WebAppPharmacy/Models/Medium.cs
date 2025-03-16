using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Medium
{
    public long Id { get; set; }

    public string ModelType { get; set; } = null!;

    public long ModelId { get; set; }

    public string? Uuid { get; set; }

    public string CollectionName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string? MimeType { get; set; }

    public string Disk { get; set; } = null!;

    public string? ConversionsDisk { get; set; }

    public long Size { get; set; }

    public string Manipulations { get; set; } = null!;

    public string CustomProperties { get; set; } = null!;

    public string GeneratedConversions { get; set; } = null!;

    public string ResponsiveImages { get; set; } = null!;

    public long? OrderColumn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
