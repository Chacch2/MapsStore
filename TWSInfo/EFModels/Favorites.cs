using System;
using System.Collections.Generic;

namespace TWSInfo.EFModels;

public partial class Favorites
{
    public int FavoriteId { get; set; }

    public int? UserId { get; set; }

    public int? StoreId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Stores? Store { get; set; }

    public virtual Users? User { get; set; }
}
