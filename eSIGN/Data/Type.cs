using System;
using System.Collections.Generic;

namespace eSIGN.Data;

/// <summary>
/// Loai user yeu cau
/// </summary>
public partial class Type
{
    public int Id { get; set; }

    public string? Type1 { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }
}
