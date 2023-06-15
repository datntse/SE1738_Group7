using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblFavouriteList
{
    public string FavouriteListId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? ProductId { get; set; }

    public virtual TblProduct? Product { get; set; }

    public virtual TblUser? User { get; set; }
}
