using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieukiemkho
{
    public int Id { get; set; }

    public string? Sophieukiemkho { get; set; }

    public string? Ngaykiemkho { get; set; }

    public int? Idnhanvien { get; set; }

    public string? Ghichu { get; set; }

    public bool? Trangthai { get; set; }

    public string? Ngaychinhsua { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
