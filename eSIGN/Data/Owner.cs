using System;
using System.Collections.Generic;

namespace eSIGN.Data;

public partial class Owner
{
    public int Id { get; set; }

    public string? IdCard { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }
}
