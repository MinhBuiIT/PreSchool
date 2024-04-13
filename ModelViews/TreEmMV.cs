using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLPreschool.ModelViews
{
    public class TreEmMV
    {
        public string idPh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [MinLength(4, ErrorMessage = "Tên tối thiểu 4 ký tự")]
        [DisplayName("Tên Trẻ Em")]
        public string TenTe { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn {0}")]
        [DisplayName("Ngày sinh trẻ em")]
        public DateTime NgaySinhTE { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn {0}")]
        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn {0}")]
        [DisplayName("Hình đại diện")]
        public IFormFile AvatarTE { get; set; }
    }
}
