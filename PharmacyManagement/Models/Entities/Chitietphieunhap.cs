using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Chitietphieunhap
{
    public int Id { get; set; }

    public int? Idsanpham { get; set; }

    public int? Soluong { get; set; }

    public double? Gianhap { get; set; }

    public double? Thanhtien { get; set; }

    public virtual Sanpham? IdsanphamNavigation { get; set; }
}
