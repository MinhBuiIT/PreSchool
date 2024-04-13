using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLPreschool.ModelViews
{
    public class RoleMV
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [DisplayName("Role mới")]
        public string Name { get; set; }
    }
}
