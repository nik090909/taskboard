using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Web.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}