using System;
using System.Collections.Generic;

namespace eSIGN.Data;

public partial class SystemOwner
{
    public int Id { get; set; }

    public int? IdSystem { get; set; }

    public int? IdOwner { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }
}
