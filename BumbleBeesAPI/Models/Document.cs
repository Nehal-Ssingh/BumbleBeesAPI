using System;
using System.Collections.Generic;

namespace BumbleBeesAPI.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public string? Fuuid { get; set; }

    public DateOnly? DocumentDate { get; set; }

    public string? FirebaseUrl { get; set; }

    public string? CategoryName { get; set; }

    public virtual Category? CategoryNameNavigation { get; set; }

    public virtual UserProfile? Fuu { get; set; }
}
