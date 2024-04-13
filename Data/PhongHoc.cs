using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class PhongHoc
{
    public string MaPhong { get; set; } = null!;

    [Column(TypeName = "nvarchar")]
    public string TenPhong { get; set; } = null!;

    public int SucChua { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
