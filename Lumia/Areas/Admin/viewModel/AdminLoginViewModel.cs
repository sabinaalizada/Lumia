using System.ComponentModel.DataAnnotations;

namespace Lumia.Areas.Admin.viewModel
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
