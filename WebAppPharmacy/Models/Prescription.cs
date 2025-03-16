using System;
using System.Collections.Generic;

namespace WebAppPharmacy.Models;

public partial class Prescription
{
    public long Id { get; set; }

    public string PrescriptionCode { get; set; } = null!;

    public long? CustomerId { get; set; }

    public string? DoctorName { get; set; }

    public string? Notes { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<PrescriptionProduct> PrescriptionProducts { get; set; } = new List<PrescriptionProduct>();
}
