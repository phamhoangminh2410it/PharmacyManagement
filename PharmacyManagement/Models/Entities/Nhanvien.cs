using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Nhanvien
{
    public int Id { get; set; }

    public string? Manhanvien { get; set; }

    public string? Tennhanvien { get; set; }

    public string? Diachi { get; set; }

    public string? Sodienthoai { get; set; }

    public string? Email { get; set; }

    public string? Cmnd { get; set; }

    public string? Username { get; set; }

    public string? Pass { get; set; }

    public bool? Trangthai { get; set; }

    public int? Idchucvu { get; set; }

    public string? Avatar { get; set; }

    public virtual Chucvu? IdchucvuNavigation { get; set; }

    public virtual ICollection<Phieubansanpham> Phieubansanphams { get; set; } = new List<Phieubansanpham>();

    public virtual ICollection<Phieuchi> Phieuchis { get; set; } = new List<Phieuchi>();

    public virtual ICollection<Phieudoitra> Phieudoitras { get; set; } = new List<Phieudoitra>();

    public virtual ICollection<Phieukiemkho> Phieukiemkhos { get; set; } = new List<Phieukiemkho>();

    public virtual ICollection<Phieunhap> Phieunhaps { get; set; } = new List<Phieunhap>();

    public virtual ICollection<Phieuxuat> Phieuxuats { get; set; } = new List<Phieuxuat>();
}
