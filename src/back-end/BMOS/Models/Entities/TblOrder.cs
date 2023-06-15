using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblOrder
{
    public string OrderId { get; set; } = null!;

    public string? UserId { get; set; }

    public double? TotalPrice { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsConfirm { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblRefund> TblRefunds { get; set; } = new List<TblRefund>();

    public virtual TblUser? User { get; set; }
}
