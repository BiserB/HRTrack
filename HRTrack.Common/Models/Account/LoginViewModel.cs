using System.ComponentModel.DataAnnotations;

namespace HRTrack.Common.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Полето Имейл трябва да е попълнено")]
        [Display(Name = "Имейл")]
        [EmailAddress(ErrorMessage = "Изисква се валиден имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето Парола трябва да е попълнено")]
        [Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
