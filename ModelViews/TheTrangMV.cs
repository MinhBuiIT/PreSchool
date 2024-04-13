using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLPreschool.ModelViews
{
    public class TheTrangMV
    {
        public string MaTe {  get; set; }
        public string Nam { get; set; }
        public string Thang { get; set; }

        [DisplayName("Chiều Cao")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public double ChieuCao { get; set; }

        [DisplayName("Cân Nặng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public double CanNang { get; set; }
    }
}
