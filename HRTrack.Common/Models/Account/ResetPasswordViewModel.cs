using System.ComponentModel.DataAnnotations;

namespace HRTrack.Common.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Полето Имейл трябва да е попълнено")]
        [EmailAddress(ErrorMessage = "Изисква се валиден имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето Парола трябва да е попълнено")]
        [StringLength(128, ErrorMessage = "{0} трябва да е от {2} до {1} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
