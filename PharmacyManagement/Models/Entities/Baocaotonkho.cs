using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Baocaotonkho
{
    public int Id { get; set; }

    public string? Ngaylap { get; set; }

    public int? Idsanpham { get; set; }

    public int? Soluongtondau { get; set; }

    public int? Soluongnhap { get; set; }

    public int? Soluongxuat { get; set; }

    public int? Soluongtoncuoi { get; set; }

    public virtual Sanpham? IdsanphamNavigation { get; set; }
}
