using QLPreschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPreschool.Data;

public partial class PhuHuynh
{
    public string MaPh { get; set; } = null!;

    [Column(TypeName = "nvarchar")]
    public string TenPh { get; set; } = null!;

    [StringLength(11, MinimumLength = 1)]
    [Column(TypeName = "varchar")]
    public string SdtPhuhuynh { get; set; }

    [Required]
    public bool GioiTinh { get; set; }

    [Column(TypeName = "Date")]
    public DateTime NgaySinh { get; set; }

    [Column(TypeName = "nvarchar")]
    public string DiaChiPh { get; set; } = null!;

    public AppUser User { get; set; }
    public virtual ICollection<TreEm> TreEms { get; set; } = new List<TreEm>();
}
