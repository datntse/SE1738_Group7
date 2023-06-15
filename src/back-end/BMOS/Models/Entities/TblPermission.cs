using System;
using System.Collections.Generic;

namespace BMOS.Models.Entities;

public partial class TblPermission
{
    public string PermissionId { get; set; } = null!;

    public string? UserRoleId { get; set; }

    public string? PermissionName { get; set; }
}
