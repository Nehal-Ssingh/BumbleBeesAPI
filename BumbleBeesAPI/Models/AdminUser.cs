using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class AdminUser
{
    public int AdminId { get; set; }

    public string? Fuuid { get; set; }

    public int? CertifiedId { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<AdminTask> AdminTasks { get; set; } = new List<AdminTask>();

    public virtual UserProfile? Fuu { get; set; }
}
