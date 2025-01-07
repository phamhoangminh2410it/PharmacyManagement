using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieuxuat
{
    public int Id { get; set; }

    public string? Sophieuxuat { get; set; }

    public string? Ngayxuat { get; set; }

    public int? Idnhanvien { get; set; }

    public string? Lydoxuat { get; set; }

    public double? Tongtien { get; set; }

    public bool? Trangthai { get; set; }

    public string? Ngaychinhsua { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
