using System;
using System.Collections.Generic;

namespace TWSInfo.Models.EFModels;

public partial class Users
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Favorites> Favorites { get; set; } = new List<Favorites>();
}
