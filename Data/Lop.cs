using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string MaLoai { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    [Required(ErrorMessage ="Vui lòng nhập {0}")]
    [Column(TypeName = "nvarchar")]
    [DisplayName("Tên lớp")]
    public string TenLop { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập {0}")]
    [DisplayName("Sỉ số")]
    public int SiSo { get; set; }

    public virtual ICollection<GiangDay> GiangDays { get; set; } = new List<GiangDay>();

    public virtual LoaiLop MaLoaiNavigation { get; set; } = null!;

    public virtual PhongHoc MaPhongNavigation { get; set; } = null!;

    public virtual ICollection<TreEm> MaTes { get; set; } = new List<TreEm>();
}
