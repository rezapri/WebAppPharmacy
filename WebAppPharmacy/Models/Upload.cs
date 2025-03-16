using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Upload
{
    public long Id { get; set; }

    public string Folder { get; set; } = null!;

    public string Filename { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
