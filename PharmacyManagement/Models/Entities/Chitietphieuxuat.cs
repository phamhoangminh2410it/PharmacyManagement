using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Chitietphieuxuat
{
    public int Id { get; set; }

    public int? Idsanpham { get; set; }

    public int? Soluong { get; set; }

    public double? Gia { get; set; }

    public double? Thanhtien { get; set; }

    public virtual Sanpham? IdsanphamNavigation { get; set; }
}
