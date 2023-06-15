using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblProduct
{
    public string ProductId { get; set; } = null!;

    public string? Name { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public double? Weight { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsLoved { get; set; }

    public bool? Status { get; set; }



    public virtual ICollection<TblFavouriteList> TblFavouriteLists { get; set; } = new List<TblFavouriteList>();

    public virtual ICollection<TblFeedback> TblFeedbacks { get; set; } = new List<TblFeedback>();

    public virtual ICollection<TblImage> TblImages { get; set; } = new List<TblImage>();

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblRouting> TblRoutings { get; set; } = new List<TblRouting>();
}
