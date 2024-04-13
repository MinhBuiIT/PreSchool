using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class LoaiLop
{
    public string MaLoai { get; set; } = null!;

    [Column(TypeName = "nvarchar")]
    public string TenLoai { get; set; } = null!;

    public int DoTuoiBatDau { get; set; }

    public int? DoTuoiKetThuc { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual ICollection<MonHoc> MaMons { get; set; } = new List<MonHoc>();
}
