using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Chucvu
{
    public int Id { get; set; }

    public string? Machucvu { get; set; }

    public string? Tenchucvu { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
