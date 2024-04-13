using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLPreschool.ModelViews
{
    public class PhuHuynhMV
    {

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [MinLength(4,ErrorMessage = "Tối thiểu 4 ký tự")]
        [DisplayName("Tên phụ huynh")]
        public string TenPh { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Phone(ErrorMessage = "Không đúng định dạng điện thoại")]
        [DisplayName("Số điện thoại")]
        public string SdtPhuhuynh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Địa chỉ")]
        public string DiaChiPh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng Email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DisplayName("Mật Khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Tối thiểu 8 ký tự, ít nhất một in hoa, thường,một số,ký tự đặc biệt")]
        public string MatKhau { get; set; }
    }
}
