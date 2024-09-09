using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? OrganisationRegNo { get; set; }

    public bool? Active { get; set; }

    public string? ProjectStatus { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? ProjectDate { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? ProjectDescription { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Organisation? OrganisationRegNoNavigation { get; set; }
}
