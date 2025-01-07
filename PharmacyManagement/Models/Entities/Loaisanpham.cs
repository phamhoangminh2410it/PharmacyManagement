using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Loaisanpham
{
    public int Id { get; set; }

    public string? Maloaisanpham { get; set; }

    public string? Tenloaisanpham { get; set; }

    public int? Phantramloinhuan { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
