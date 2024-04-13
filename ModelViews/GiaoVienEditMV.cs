using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLPreschool.ModelViews
{
    public class GiaoVienEditMV
    {
        [DisplayName("Tên Giáo Viên")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Độ dài {0} tối thiểu {2} đến {1}")]
        public string TenGV { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [DisplayName("Địa chỉ")]
        [MinLength(3, ErrorMessage = "Độ dài tối thiểu 3 ký tự")]
        public string DiaChi { get; set; }

        [DisplayName("Chức vụ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài {0} tối thiểu {2} đến {1}")]
        public string ChucVu { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [DisplayName("Hình đại diện")]
        public IFormFile? AvatarGV { get; set; }

        
    }
}
