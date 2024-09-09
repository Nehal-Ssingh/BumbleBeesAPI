using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class AdminTask
{
    public int TaskId { get; set; }

    public int? AdminId { get; set; }

    public DateOnly? TaskDate { get; set; }

    public string? TaskName { get; set; }

    public virtual AdminUser? Admin { get; set; }
}
