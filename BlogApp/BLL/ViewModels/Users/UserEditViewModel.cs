using BlogApp.BLL.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogApp.BLL.ViewModels.Users
{
    public class UserEditViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Имя")]
        public string? FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Фамилия")]
        public string? LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Никнейм", Prompt = "Никнейм")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string? NewPassword { get; set; }

        [Display(Name = "Роли")]
        public List<RoleViewModel>? Roles { get; set; }

        public Guid Id { get; set; }
    }
}
