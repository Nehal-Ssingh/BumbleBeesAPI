using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class Organisation
{
    public string OrganisationRegNo { get; set; } = null!;

    public string? OrganisationName { get; set; }

    public string? Fuuid { get; set; }

    public string? DirectorFullName { get; set; }

    public string? DirectorIdnumber { get; set; }

    public string? DirectorContactNo { get; set; }

    public string? Email { get; set; }

    public virtual UserProfile? Fuu { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
