using System.ComponentModel.DataAnnotations;

namespace HRTrack.Common.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Полето Имейл трябва да е попълнено")]
        [Display(Name = "Имейл")]
        [EmailAddress(ErrorMessage = "Изисква се валиден имейл")]
        public string Email { get; set; }
    }
}
