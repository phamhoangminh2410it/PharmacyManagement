using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Chitietphieukiemkho
{
    public int Id { get; set; }

    public int? Idsanpham { get; set; }

    public int? Soluonghientai { get; set; }

    public int? Soluongkiemtra { get; set; }

    public virtual Sanpham? IdsanphamNavigation { get; set; }
}
