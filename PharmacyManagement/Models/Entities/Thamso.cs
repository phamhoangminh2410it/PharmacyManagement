using System;
using System.Collections.Generic;

namespace PharmacyManagement.Models.Entities;

public partial class Thamso
{
    public int Id { get; set; }

    public string? Mathamso { get; set; }

    public string? Tenthamso { get; set; }

    public double? Giatri { get; set; }

    public string? Ngayapdung { get; set; }
}
