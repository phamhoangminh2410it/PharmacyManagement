using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Sanpham
{
    public int Id { get; set; }

    public string? Masanpham { get; set; }

    public string? Tensanpham { get; set; }

    public double? Giaban { get; set; }

    public double? Giamgia { get; set; }

    public int? Soluongton { get; set; }

    public string? Donvitinh { get; set; }

    public string? Mota { get; set; }

    public string? Xuatxu { get; set; }

    public string? Thoigiansanxuat { get; set; }

    public string? Thogiansudung { get; set; }

    public string? Hinhanh { get; set; }

    public int? Idloaisanpham { get; set; }

    public bool? Trangthai { get; set; }

    public virtual ICollection<Baocaotonkho> Baocaotonkhos { get; set; } = new List<Baocaotonkho>();

    public virtual ICollection<Chitietphieubansanpham> Chitietphieubansanphams { get; set; } = new List<Chitietphieubansanpham>();

    public virtual ICollection<Chitietphieukiemkho> Chitietphieukiemkhos { get; set; } = new List<Chitietphieukiemkho>();

    public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; } = new List<Chitietphieunhap>();

    public virtual ICollection<Chitietphieuxuat> Chitietphieuxuats { get; set; } = new List<Chitietphieuxuat>();

    public virtual Loaisanpham? IdloaisanphamNavigation { get; set; }

    public virtual ICollection<Phieudoitra> Phieudoitras { get; set; } = new List<Phieudoitra>();
}
