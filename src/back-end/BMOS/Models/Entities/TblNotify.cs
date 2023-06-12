using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblNotify
{
    public string NotifyId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Message { get; set; }

    public string? Type { get; set; }

    public DateTime? Date { get; set; }

    public virtual TblUser? User { get; set; }
}
