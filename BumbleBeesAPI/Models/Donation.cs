using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public string? CompanyRegNo { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? DonationDate { get; set; }

    public virtual Company? CompanyRegNoNavigation { get; set; }
}
