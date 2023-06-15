using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblBlog
{
    public string BlogId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<TblImage> TblImages { get; set; } = new List<TblImage>();
}
