using QLPreschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QLPreschool.Data;

public partial class GiaoVien
{
    public string MaGv { get; set; } = null!;

    public AppUser User { get; set; }

    [Column(TypeName = "nvarchar")]
    public string TenGv { get; set; } = null!;

    [AllowNull]
    [Column(TypeName = "varchar")]
    [StringLength(150,MinimumLength = 1)]
    public string? AvatarGV {  get; set; }

    [Column(TypeName = "nvarchar")]
    public string ChucVu { get; set; } = null!;

    [StringLength(11,MinimumLength = 1)]
    [Column(TypeName = "varchar")]
    public string SdtGv { get; set; }

    [Column(TypeName = "bit")]
    public bool GioiTinh { get; set; }


    [Column(TypeName = "ntext")]
    public string DiaChi { get; set; }

    public virtual ICollection<GiangDay> GiangDays { get; set; } = new List<GiangDay>();
}
