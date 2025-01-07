using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieuchi
{
    public int Id { get; set; }

    public string? Sophieuchi { get; set; }

    public string? Ngaychi { get; set; }

    public int? Idnhanvien { get; set; }

    public double? Tongtienchi { get; set; }

    public string? Ghichu { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
