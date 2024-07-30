using System;
using System.Collections.Generic;

namespace eSIGN.Data;

public partial class SignFlow
{
    public int Id { get; set; }

    public int? IdApplication { get; set; }

    public string? IdCard { get; set; }

    public int? Sequence { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? ValueSign { get; set; }

    public string? Comment { get; set; }

    public string? File { get; set; }
}
