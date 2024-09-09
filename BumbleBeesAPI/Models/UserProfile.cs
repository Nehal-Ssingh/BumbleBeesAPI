using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class UserProfile
{
    public string Fuuid { get; set; } = null!;

    public string? Role { get; set; }

    public virtual ICollection<AdminUser> AdminUsers { get; set; } = new List<AdminUser>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Organisation? Organisation { get; set; }
}
