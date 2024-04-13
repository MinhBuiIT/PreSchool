using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLPreschool.ModelViews
{
    public class TTTreEmMV
    {
        [MinLength(4, ErrorMessage = "Tối thiểu 4 ký tự")]
        [DisplayName("Tên phụ huynh")]
        public string TenPh { get; set; } = null!;

        [Phone(ErrorMessage = "Không đúng định dạng điện thoại")]
        [DisplayName("Số điện thoại")]
        public string SdtPhuhuynh { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinhPh { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinhPh { get; set; }


        [DisplayName("Địa chỉ")]
        public string DiaChiPh { get; set; }

        [MinLength(4, ErrorMessage = "Tên tối thiểu 4 ký tự")]
        [DisplayName("Tên Trẻ Em")]
        public string TenTe { get; set; }

        public string? MaTe { get; set; }

        [DisplayName("Ngày sinh trẻ em")]
        public DateTime NgaySinhTE { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [DisplayName("Hình đại diện")]
        public IFormFile? AvatarTE { get; set; }

        public string? Photo { get; set; }
    }
}
