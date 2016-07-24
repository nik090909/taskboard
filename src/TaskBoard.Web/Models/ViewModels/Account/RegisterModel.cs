using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Web.Models.ViewModels.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}