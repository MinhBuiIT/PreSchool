using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class TreEm
{
    public string MaTe { get; set; } = null!;

    public string MaPh { get; set; } = null!;

    [Column(TypeName = "nvarchar")]
    public string TenTe { get; set; } = null!;

    [Column(TypeName = "Date")]
    public DateTime NgaySinhTE { get; set; }

    [Required]
    public bool GioiTinh { get; set; }

    [Column(TypeName = "varchar")]
    [StringLength(150, MinimumLength = 1)]
    public string AvatarTE { get;set; }

    public virtual PhuHuynh MaPhNavigation { get; set; } = null!;

    public virtual ICollection<PhieuLienLac> PhieuLienLacs { get; set; } = new List<PhieuLienLac>();

    public virtual ICollection<TheTrang> TheTrangs { get; set; } = new List<TheTrang>();

    public virtual ICollection<Lop> MaLops { get; set; } = new List<Lop>();
}
