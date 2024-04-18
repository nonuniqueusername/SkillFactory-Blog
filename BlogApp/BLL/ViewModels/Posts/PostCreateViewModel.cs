using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlogApp.BLL.ViewModels.Tags;

namespace BlogApp.BLL.ViewModels.Posts
{
    public class PostCreateViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? AuthorId { get; set; }
        public List<TagViewModel>? Tags { get; set; }

        [Required(ErrorMessage = "Поле Заголовок обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Поле Описание обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string? Content { get; set; }
    }
}
