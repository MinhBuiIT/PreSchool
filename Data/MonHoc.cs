using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class MonHoc
{
    public string MaMon { get; set; } = null!;

    [Column(TypeName = "nvarchar")]
    public string? TenMon { get; set; }

    public virtual ICollection<LoaiLop> MaLoais { get; set; } = new List<LoaiLop>();
}
