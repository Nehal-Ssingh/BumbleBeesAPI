using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class Company
{
    public string CompanyRegNo { get; set; } = null!;

    public string? Fuuid { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyTelephone { get; set; }

    public string? Email { get; set; }

    public int? TaxNo { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual UserProfile? Fuu { get; set; }
}
