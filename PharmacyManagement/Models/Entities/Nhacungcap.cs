using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Nhacungcap
{
    public int Id { get; set; }

    public string? Manhacungcap { get; set; }

    public string? Tennhacungcap { get; set; }

    public string? Diachi { get; set; }

    public string? Sodienthoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Phieunhap> Phieunhaps { get; set; } = new List<Phieunhap>();
}
