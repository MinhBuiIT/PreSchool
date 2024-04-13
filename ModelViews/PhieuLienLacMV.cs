using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLPreschool.ModelViews
{
    public class PhieuLienLacMV
    {
        public string MaTe { get; set; }
        public string Nam { get; set; }
        public string Thang { get; set; }

        [DisplayName("Lời Nhận Xét")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string LoiNhanXet { get; set; }
    }
}
