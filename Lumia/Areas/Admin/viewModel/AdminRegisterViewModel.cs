using System.ComponentModel.DataAnnotations;

namespace Lumia.Areas.Admin.viewModel
{
    public class AdminRegisterViewModel
    {
        [StringLength(maximumLength: 150, MinimumLength = 3)]

        public string FullName { get; set; }
        [StringLength(maximumLength: 150, MinimumLength = 3)]


        public string Username { get; set; }
        [StringLength(maximumLength: 150, MinimumLength = 3)]

        public string EmaIL { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
