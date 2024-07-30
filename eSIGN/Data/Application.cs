using System;
using System.Collections.Generic;

namespace eSIGN.Data;

public partial class Application
{
    public int Id { get; set; }

    /// <summary>
    /// loai don: Improvement, New development
    /// </summary>
    public int? IdType { get; set; }

    public string? IdCardUserRequire { get; set; }

    public string? NameUserRequire { get; set; }

    public string? IdCardUserCreate { get; set; }

    public int? IdSystem { get; set; }

    public int? IdSystemOwner { get; set; }

    public string? BussinessJustification { get; set; }

    public string? AdditionalComments { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? IdCardGlobalManager { get; set; }

    public string? NameManager { get; set; }

    public int? ValueSign { get; set; }

    public string? File { get; set; }
}
