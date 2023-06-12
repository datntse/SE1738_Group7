using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblImage
{
    public string ImageId { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? RoutingId { get; set; }

    public string? BlogId { get; set; }

    public string? RefundId { get; set; }

    public string? UserId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Type { get; set; }

    public virtual TblBlog? Blog { get; set; }

    public virtual TblProduct? Product { get; set; }

    public virtual TblRefund? Refund { get; set; }

    public virtual TblRouting? Routing { get; set; }

    public virtual TblUser? User { get; set; }
}
