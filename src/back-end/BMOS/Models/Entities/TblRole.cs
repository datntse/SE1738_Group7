using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblRole
{
    public string UserRoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public virtual TblPermission UserRole { get; set; } = null!;

    public virtual TblUser UserRoleNavigation { get; set; } = null!;
}
