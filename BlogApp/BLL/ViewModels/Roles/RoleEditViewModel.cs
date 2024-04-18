using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogApp.BLL.ViewModels.Roles
{
    public class RoleEditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание роли", Prompt = "описание")]
        public string? Description { get; set; } = null;
    }
}
