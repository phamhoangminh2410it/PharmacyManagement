using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieunhap
{
    public int Id { get; set; }

    public string? Sophieunhap { get; set; }

    public string? Ngaynhap { get; set; }

    public int? Idnhanvien { get; set; }

    public int? Idnhacungcap { get; set; }

    public double? Tongtien { get; set; }

    public string? Ghichu { get; set; }

    public bool? Trangthai { get; set; }

    public string? Ngaychinhsua { get; set; }

    public virtual Nhacungcap? IdnhacungcapNavigation { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
