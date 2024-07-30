using System;
using System.Collections.Generic;

namespace eSIGN.Data;

public partial class LogInfo
{
    public long Id { get; set; }

    public string? Proc { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? IdCard { get; set; }

    public string? Info { get; set; }

    public string? TypeLog { get; set; }

    public string? Function { get; set; }
}
