using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieudoitra
{
    public int Id { get; set; }

    public string? Sophieudoitra { get; set; }

    public string? Ngaylap { get; set; }

    public string? Ngaygiao { get; set; }

    public int? Idnhanvien { get; set; }

    public string? Tennhacungcap { get; set; }

    public string? Sodienthoai { get; set; }

    public double? Tongtien { get; set; }

    public string? Ghichu { get; set; }

    public int? Idsanpham { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }

    public virtual Sanpham? IdsanphamNavigation { get; set; }
}
