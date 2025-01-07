using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Phieubansanpham
{
    public int Id { get; set; }

    public string? Sophieubansanpham { get; set; }

    public string? Ngayban { get; set; }

    public int? Idnhanvien { get; set; }

    public string? Tenkhachhang { get; set; }

    public string? Sodienthoai { get; set; }

    public double? Tongtien { get; set; }

    public string? Ghichu { get; set; }

    public bool? Trangthai { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
